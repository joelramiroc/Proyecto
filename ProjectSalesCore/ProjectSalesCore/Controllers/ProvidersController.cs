// <copyright file="ProvidersController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ProjectSalesCore.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using CSales.Database.Contexts;
    using CSales.Database.Models;
    using CSales.Database.Repositories;
    using ProjectSalesCore.DataBase.Models;
    using ProjectSalesCore.ViewModel.Provider;

    public class ProvidersController : Controller
    {
        //        private readonly IRepository<CSales.Database.Models.Provider> providerRepository;
        private MyContext db = new MyContext();

        public ProvidersController()//IRepository<CSales.Database.Models.Provider> providerRepository)
        {
            //          this.providerRepository = providerRepository;
        }

        // GET: Providers
        public ActionResult Index()
        {

            var provider = db.Provider.Include(p => p.BusinessName);
            return View(provider.ToList());
        }

        // GET: Providers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CSales.Database.Models.Provider provider = this.db.Provider.Find(id);
            if (provider == null)
            {
                return HttpNotFound();
            }

            var prov = new DetailsProviderViewModel
            {
                Contact = provider.Contact,
                Id = provider.Id,
                IdBusinessName = provider.BusinessName.Id,
                IsActive = provider.IsActive,
                IsForeignProvider = provider.IsForeignProvider,
                Name = provider.Name,
                Telephones = this.db.TelephoneProvider.Where(t => t.IdPRV == provider.Id),
                Addresses = this.db.AddressProvider.Where(a => a.IdPRV == provider.Id),
                CitiesDistricts = this.db.CityProvider.Where(cd => cd.IdProv == provider.Id)
            };
            return View(prov);
        }

        // GET: Providers/Create
        public ActionResult Create()
        {
            ViewBag.IdBusinessName = new SelectList(db.BusinessName, "Id", "Name");
            return View(new CreateProviderViewModel());
        }

        // POST: Providers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateProviderViewModel provider)
        {
            if (ModelState.IsValid)
            {
                var P = new CSales.Database.Models.Provider
                {
                    Contact = provider.Contact,
                    IsActive = provider.IsActive,
                    Name = provider.Name,
                    IsForeignProvider = provider.IsForeignProvider,
                };

                this.db.Database.ExecuteSqlCommand(@"INSERT INTO PROVIDER(NAME, ISACTIVE, CONTACT, ISFOREIGNPROVIDER, BUSINESSNAME, CREATEDDATE) values ({0},{1},{2},{3},{4},{5})", provider.Name, provider.IsActive, provider.Contact, provider.IsForeignProvider, provider.IdBusinessName, DateTime.Now);

                var newProv = this.db.Provider.OrderByDescending(x => x.Id).FirstOrDefault();

                for (int i = 0; i < provider.Addresses.Count(); i++)
                {
                    this.db.Database.ExecuteSqlCommand(@"INSERT INTO APRV(ADDRESSNAME,DESCRIPTION,IDPRV) values ({0},{1},{2})", provider.Addresses.ElementAt(i), "Descripcion default", newProv.Id);
                }

                for (int i = 0; i < provider.Telephones.Count(); i++)
                {
                    this.db.Database.ExecuteSqlCommand(@"INSERT INTO TELPROV(NUMBER,DESCRIPTION,IDPRV) values ({0},{1},{2})", provider.Telephones.ElementAt(i), "Descripcion default", newProv.Id);
                }

                var cCorriente = new CurrentAccountProvider
                {
                    CreatedDate = DateTime.Now,
                    IdProvider = newProv.Id,
                    TotalDebt = 0
                };

                this.db.CurrentAcountProvider.Add(cCorriente);
                this.db.SaveChanges();

                return this.RedirectToAction("Index");
            }

            this.ViewBag.IdBusinessName = new SelectList(db.BusinessName, "Id", "Name", provider.IdBusinessName);
            return View(provider);
        }

        // GET: Providers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Provider provider = db.Provider.Find(id);

            if (provider == null)
            {
                return HttpNotFound();
            }

            ViewBag.IdBusinessName = new SelectList(db.BusinessName, "Id", "Name", provider.IdBusinessName);
            return View(provider);
        }

        // POST: Providers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,IsActive,Contact,IsForeignProvider,IdBusinessName,CreatedDate")] Provider provider)
        {
            if (ModelState.IsValid)
            {
                db.Entry(provider).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.IdBusinessName = new SelectList(db.BusinessName, "Id", "Name", provider.IdBusinessName);
            return View(provider);
        }

        // GET: Providers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provider provider = db.Provider.Find(id);
            if (provider == null)
            {
                return HttpNotFound();
            }
            return View(provider);
        }

        // POST: Providers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Provider provider = db.Provider.Find(id);
            db.Provider.Remove(provider);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

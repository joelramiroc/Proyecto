// <copyright file="ClientsController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ProjectSalesCore.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using CSales.Database.Contexts;
    using CSales.Database.Models;
    using ProjectSalesCore.DataBase.Models;
    using ProjectSalesCore.ViewModel.Client;

    public class ClientsController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Clients
        public ActionResult Index()
        {
            var client = db.Client.Include(c => c.Employee).Include(c => c.RUC);
            return View(client.ToList());
        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Client client = db.Client.Find(id);

            if (client == null)
            {
                return HttpNotFound();
            }

            var nc = new DetailClientViewModel
            {
                Addresses = this.db.AddressClient.Where(a => a.IdClient == client.Id).ToList(),
                Emails = this.db.EmailClient.Where(e => e.IdClient == client.Id),
                IdRUC = client.IdRUC,
                Id = client.Id,
                CitiesDistricts = this.db.CityClient.Where(c => c.IdClient == client.Id),
                Telephones = this.db.TelephoneClient.Where(t => t.IdClient == client.Id),
                Name = client.Name,
                IdEmployee = client.IdEmployee,
                Employee = this.db.Employee.Find(client.IdEmployee),
                RUC = this.db.RUC.Find(client.IdRUC)
            };

            return View(nc);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            ViewBag.IdEmployee = new SelectList(db.Employee, "Id", "Name");
            ViewBag.IdRUC = new SelectList(db.RUC, "IdRUC", "RUCName");
            return View(new CreateClientViewModel());
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateClientViewModel client)
        {
            if (ModelState.IsValid)
            {
                var nc = new Client
                {
                    IdEmployee = client.IdEmployee,
                    IdRUC = client.IdRUC,
                    Name = client.Name
                };

                var newc = this.db.Client.Add(nc);
                this.db.SaveChanges();

                for (int i = 0; i < client.Addresses.Count(); i++)
                {
                    var na = new AddressClient
                    {
                        AddressName = client.Addresses.ElementAt(i),
                        IdClient = newc.Id,
                        Description = "Default description"
                    };

                    this.db.AddressClient.Add(na);
                    this.db.SaveChanges();
                }

                for (int i = 0; i < client.Telephones.Count(); i++)
                {
                    var nt = new TelephoneClient
                    {
                        Description = "Default description",
                        IdClient = newc.Id,
                        Number = client.Telephones.ElementAt(i)
                    };

                    this.db.TelephoneClient.Add(nt);
                    this.db.SaveChanges();
                }

                for (int i = 0; i < client.Emails.Count(); i++)
                {
                    var ne = new EmailClient
                    {
                        IdClient = newc.Id,
                        Emaill = client.Emails.ElementAt(i)
                    };
                    this.db.EmailClient.Add(ne);
                    this.db.SaveChanges();

                    var c = new CustomerCheckingAccount
                    {
                        IdClient = newc.Id,
                        CreatedDate = DateTime.Now,
                        TotalDebt = 0
                    };
                    this.db.CustomerCheckingAccount.Add(c);
                    this.db.SaveChanges();
                }

                return this.RedirectToAction("Index");
            }

            ViewBag.IdEmployee = new SelectList(db.Employee, "Id", "Name", client.IdEmployee);
            ViewBag.IdRUC = new SelectList(db.RUC, "IdRUC", "RUCName", client.IdRUC);
            return View(client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Client.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEmployee = new SelectList(db.Employee, "Id", "Name", client.IdEmployee);
            ViewBag.IdRUC = new SelectList(db.RUC, "IdRUC", "RUCName", client.IdRUC);
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,IdRUC,IdEmployee")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEmployee = new SelectList(db.Employee, "Id", "Name", client.IdEmployee);
            ViewBag.IdRUC = new SelectList(db.RUC, "IdRUC", "RUCName", client.IdRUC);
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Client.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Client.Find(id);
            db.Client.Remove(client);
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

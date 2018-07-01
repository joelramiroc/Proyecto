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
    using CSales.Database.Repositories;
    using ViewModel.Storage;
    using DataBase.Models;

    public class StoragesController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Storages
        public ActionResult Index()
        {
            return View(db.Storage.ToList());
        }

        // GET: Storages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Storage storage = db.Storage.Find(id);
            if (storage == null)
            {
                return HttpNotFound();
            }
            return View(storage);
        }

        // GET: Storages/Create
        public ActionResult Create()
        {
            return View(new CreateStorageViewModel());
        }

        // POST: Storages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateStorageViewModel storage)
        {
            if (ModelState.IsValid)
            {
                var sNew = new Storage
                {
                    StorageName = storage.StorageName,
                    CreatedDate = DateTime.Now
                };
                var sn = db.Storage.Add(sNew);
                db.SaveChanges();

                foreach (var item in storage.Addresses)
                {
                    var n = new AddressStorage
                    {
                        AddressName = item.ToString(),
                        Description = "DEFAULT DESCRIPTION",
                        IdStorage = sn.IdStorage,
                    };
                    this.db.AddressStorage.Add(n);
                   // this.db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            return View(storage);
        }

        // GET: Storages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Storage storage = db.Storage.Find(id);
            if (storage == null)
            {
                return HttpNotFound();
            }
            return View(storage);
        }

        // POST: Storages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdStorage,StorageName,CreatedDate")] Storage storage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(storage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(storage);
        }

        // GET: Storages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Storage storage = db.Storage.Find(id);
            if (storage == null)
            {
                return HttpNotFound();
            }
            return View(storage);
        }

        // POST: Storages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Storage storage = db.Storage.Find(id);
            db.Storage.Remove(storage);
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

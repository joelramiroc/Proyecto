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

namespace ProjectSalesCore.Controllers
{
    public class CurrentAccountProvidersController : Controller
    {
        private MyContext db = new MyContext();

        // GET: CurrentAccountProviders
        public ActionResult Index()
        {
            var currentAcountProvider = db.CurrentAcountProvider.Include(c => c.Provider);
            return View(currentAcountProvider.ToList());
        }

        // GET: CurrentAccountProviders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrentAccountProvider currentAccountProvider = db.CurrentAcountProvider.Find(id);
            if (currentAccountProvider == null)
            {
                return HttpNotFound();
            }
            return View(currentAccountProvider);
        }

        // GET: CurrentAccountProviders/Create
        public ActionResult Create()
        {
            ViewBag.IdProvider = new SelectList(db.Provider, "Id", "Name");
            return View();
        }

        // POST: CurrentAccountProviders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCurrentAccountProvider,IdProvider,TotalDebt,CreatedDate")] CurrentAccountProvider currentAccountProvider)
        {
            if (ModelState.IsValid)
            {
                db.CurrentAcountProvider.Add(currentAccountProvider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProvider = new SelectList(db.Provider, "Id", "Name", currentAccountProvider.IdProvider);
            return View(currentAccountProvider);
        }

        // GET: CurrentAccountProviders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrentAccountProvider currentAccountProvider = db.CurrentAcountProvider.Find(id);
            if (currentAccountProvider == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProvider = new SelectList(db.Provider, "Id", "Name", currentAccountProvider.IdProvider);
            return View(currentAccountProvider);
        }

        // POST: CurrentAccountProviders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCurrentAccountProvider,IdProvider,TotalDebt,CreatedDate")] CurrentAccountProvider currentAccountProvider)
        {
            if (ModelState.IsValid)
            {
                db.Entry(currentAccountProvider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProvider = new SelectList(db.Provider, "Id", "Name", currentAccountProvider.IdProvider);
            return View(currentAccountProvider);
        }

        // GET: CurrentAccountProviders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrentAccountProvider currentAccountProvider = db.CurrentAcountProvider.Find(id);
            if (currentAccountProvider == null)
            {
                return HttpNotFound();
            }
            return View(currentAccountProvider);
        }

        // POST: CurrentAccountProviders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CurrentAccountProvider currentAccountProvider = db.CurrentAcountProvider.Find(id);
            db.CurrentAcountProvider.Remove(currentAccountProvider);
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

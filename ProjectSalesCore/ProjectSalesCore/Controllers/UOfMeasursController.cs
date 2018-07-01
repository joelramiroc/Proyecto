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
    public class UOfMeasursController : Controller
    {
        private MyContext db = new MyContext();

        // GET: UOfMeasurs
        public ActionResult Index()
        {
            return View(db.UnitOfMeasurement.ToList());
        }

        // GET: UOfMeasurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UOfMeasur uOfMeasur = db.UnitOfMeasurement.Find(id);
            if (uOfMeasur == null)
            {
                return HttpNotFound();
            }
            return View(uOfMeasur);
        }

        // GET: UOfMeasurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UOfMeasurs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUnitOfMeasurement,UnitName")] UOfMeasur uOfMeasur)
        {
            if (ModelState.IsValid)
            {
                db.UnitOfMeasurement.Add(uOfMeasur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uOfMeasur);
        }

        // GET: UOfMeasurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UOfMeasur uOfMeasur = db.UnitOfMeasurement.Find(id);
            if (uOfMeasur == null)
            {
                return HttpNotFound();
            }
            return View(uOfMeasur);
        }

        // POST: UOfMeasurs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUnitOfMeasurement,UnitName")] UOfMeasur uOfMeasur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uOfMeasur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uOfMeasur);
        }

        // GET: UOfMeasurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UOfMeasur uOfMeasur = db.UnitOfMeasurement.Find(id);
            if (uOfMeasur == null)
            {
                return HttpNotFound();
            }
            return View(uOfMeasur);
        }

        // POST: UOfMeasurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UOfMeasur uOfMeasur = db.UnitOfMeasurement.Find(id);
            db.UnitOfMeasurement.Remove(uOfMeasur);
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

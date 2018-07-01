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
    public class BusinessNamesController : Controller
    {
        private MyContext db = new MyContext();

        // GET: BusinessNames
        public ActionResult Index()
        {
            return View(db.BusinessName.ToList());
        }

        // GET: BusinessNames/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessName businessName = db.BusinessName.Find(id);
            if (businessName == null)
            {
                return HttpNotFound();
            }
            return View(businessName);
        }

        // GET: BusinessNames/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BusinessNames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] BusinessName businessName)
        {
            if (ModelState.IsValid)
            {
                db.BusinessName.Add(businessName);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(businessName);
        }

        // GET: BusinessNames/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessName businessName = db.BusinessName.Find(id);
            if (businessName == null)
            {
                return HttpNotFound();
            }
            return View(businessName);
        }

        // POST: BusinessNames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] BusinessName businessName)
        {
            if (ModelState.IsValid)
            {
                db.Entry(businessName).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(businessName);
        }

        // GET: BusinessNames/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessName businessName = db.BusinessName.Find(id);
            if (businessName == null)
            {
                return HttpNotFound();
            }
            return View(businessName);
        }

        // POST: BusinessNames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BusinessName businessName = db.BusinessName.Find(id);
            db.BusinessName.Remove(businessName);
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

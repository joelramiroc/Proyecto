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
    public class RUCsController : Controller
    {
        private MyContext db = new MyContext();

        // GET: RUCs
        public ActionResult Index()
        {
            return View(db.RUC.ToList());
        }

        // GET: RUCs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RUC rUC = db.RUC.Find(id);
            if (rUC == null)
            {
                return HttpNotFound();
            }
            return View(rUC);
        }

        // GET: RUCs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RUCs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdRUC,RUCName")] RUC rUC)
        {
            if (ModelState.IsValid)
            {
                db.RUC.Add(rUC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rUC);
        }

        // GET: RUCs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RUC rUC = db.RUC.Find(id);
            if (rUC == null)
            {
                return HttpNotFound();
            }
            return View(rUC);
        }

        // POST: RUCs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRUC,RUCName")] RUC rUC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rUC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rUC);
        }

        // GET: RUCs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RUC rUC = db.RUC.Find(id);
            if (rUC == null)
            {
                return HttpNotFound();
            }
            return View(rUC);
        }

        // POST: RUCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RUC rUC = db.RUC.Find(id);
            db.RUC.Remove(rUC);
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

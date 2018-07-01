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
    public class PConditionsController : Controller
    {
        private MyContext db = new MyContext();

        // GET: PConditions
        public ActionResult Index()
        {
            return View(db.PaymentCondition.ToList());
        }

        // GET: PConditions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PCondition pCondition = db.PaymentCondition.Find(id);
            if (pCondition == null)
            {
                return HttpNotFound();
            }
            return View(pCondition);
        }

        // GET: PConditions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PConditions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPaymentCondition,ConditionName")] PCondition pCondition)
        {
            if (ModelState.IsValid)
            {
                db.PaymentCondition.Add(pCondition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pCondition);
        }

        // GET: PConditions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PCondition pCondition = db.PaymentCondition.Find(id);
            if (pCondition == null)
            {
                return HttpNotFound();
            }
            return View(pCondition);
        }

        // POST: PConditions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPaymentCondition,ConditionName")] PCondition pCondition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pCondition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pCondition);
        }

        // GET: PConditions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PCondition pCondition = db.PaymentCondition.Find(id);
            if (pCondition == null)
            {
                return HttpNotFound();
            }
            return View(pCondition);
        }

        // POST: PConditions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PCondition pCondition = db.PaymentCondition.Find(id);
            db.PaymentCondition.Remove(pCondition);
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

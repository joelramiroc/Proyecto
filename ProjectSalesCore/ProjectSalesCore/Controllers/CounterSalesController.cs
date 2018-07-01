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
    public class CounterSalesController : Controller
    {
        private MyContext db = new MyContext();

        // GET: CounterSales
        public ActionResult Index()
        {
            return View(db.CounterSale.ToList());
        }

        // GET: CounterSales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CounterSale counterSale = db.CounterSale.Find(id);
            if (counterSale == null)
            {
                return HttpNotFound();
            }
            return View(counterSale);
        }

        // GET: CounterSales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CounterSales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CreatedDate")] CounterSale counterSale)
        {
            if (ModelState.IsValid)
            {
                db.CounterSale.Add(counterSale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(counterSale);
        }

        // GET: CounterSales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CounterSale counterSale = db.CounterSale.Find(id);
            if (counterSale == null)
            {
                return HttpNotFound();
            }
            return View(counterSale);
        }

        // POST: CounterSales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CreatedDate")] CounterSale counterSale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(counterSale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(counterSale);
        }

        // GET: CounterSales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CounterSale counterSale = db.CounterSale.Find(id);
            if (counterSale == null)
            {
                return HttpNotFound();
            }
            return View(counterSale);
        }

        // POST: CounterSales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CounterSale counterSale = db.CounterSale.Find(id);
            db.CounterSale.Remove(counterSale);
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

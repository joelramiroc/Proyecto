using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CSales.Database.Contexts;
using ProjectSalesCore.DataBase.Models;

namespace ProjectSalesCore.Controllers
{
    public class StatusOrdersController : Controller
    {
        private MyContext db = new MyContext();

        // GET: StatusOrders
        public ActionResult Index()
        {
            return View(db.StatusOrder.ToList());
        }

        // GET: StatusOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusOrder statusOrder = db.StatusOrder.Find(id);
            if (statusOrder == null)
            {
                return HttpNotFound();
            }
            return View(statusOrder);
        }

        // GET: StatusOrders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatusOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdStatus,StatusName")] StatusOrder statusOrder)
        {
            if (ModelState.IsValid)
            {
                db.StatusOrder.Add(statusOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(statusOrder);
        }

        // GET: StatusOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusOrder statusOrder = db.StatusOrder.Find(id);
            if (statusOrder == null)
            {
                return HttpNotFound();
            }
            return View(statusOrder);
        }

        // POST: StatusOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdStatus,StatusName")] StatusOrder statusOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statusOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(statusOrder);
        }

        // GET: StatusOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusOrder statusOrder = db.StatusOrder.Find(id);
            if (statusOrder == null)
            {
                return HttpNotFound();
            }
            return View(statusOrder);
        }

        // POST: StatusOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StatusOrder statusOrder = db.StatusOrder.Find(id);
            db.StatusOrder.Remove(statusOrder);
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

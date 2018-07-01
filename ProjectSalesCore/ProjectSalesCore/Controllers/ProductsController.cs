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
    public class ProductsController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Products
        public ActionResult Index()
        {
            var product = db.Product.Include(p => p.ProductLine).Include(p => p.ProductType).Include(p => p.UnitOfMeasurement);
            return View(product.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.IdProductLine = new SelectList(db.ProductLine, "IdProductLine", "LineName");
            ViewBag.IdProductType = new SelectList(db.ProductType, "IdProductType", "TypeName");
            ViewBag.IdUnitOfMeasurement = new SelectList(db.UnitOfMeasurement, "IdUnitOfMeasurement", "UnitName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProduct,ProductName,IdUnitOfMeasurement,IdProductType,IdProductLine")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Product.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProductLine = new SelectList(db.ProductLine, "IdProductLine", "LineName", product.IdProductLine);
            ViewBag.IdProductType = new SelectList(db.ProductType, "IdProductType", "TypeName", product.IdProductType);
            ViewBag.IdUnitOfMeasurement = new SelectList(db.UnitOfMeasurement, "IdUnitOfMeasurement", "UnitName", product.IdUnitOfMeasurement);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProductLine = new SelectList(db.ProductLine, "IdProductLine", "LineName", product.IdProductLine);
            ViewBag.IdProductType = new SelectList(db.ProductType, "IdProductType", "TypeName", product.IdProductType);
            ViewBag.IdUnitOfMeasurement = new SelectList(db.UnitOfMeasurement, "IdUnitOfMeasurement", "UnitName", product.IdUnitOfMeasurement);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProduct,ProductName,IdUnitOfMeasurement,IdProductType,IdProductLine")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProductLine = new SelectList(db.ProductLine, "IdProductLine", "LineName", product.IdProductLine);
            ViewBag.IdProductType = new SelectList(db.ProductType, "IdProductType", "TypeName", product.IdProductType);
            ViewBag.IdUnitOfMeasurement = new SelectList(db.UnitOfMeasurement, "IdUnitOfMeasurement", "UnitName", product.IdUnitOfMeasurement);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Product.Find(id);
            db.Product.Remove(product);
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

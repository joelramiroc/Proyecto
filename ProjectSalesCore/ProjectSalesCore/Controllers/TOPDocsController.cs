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
    public class TOPDocsController : Controller
    {
        private MyContext db = new MyContext();

        // GET: TOPDocs
        public ActionResult Index()
        {
            return View(db.TypeOfPurchaseDocument.ToList());
        }

        // GET: TOPDocs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TOPDoc tOPDoc = db.TypeOfPurchaseDocument.Find(id);
            if (tOPDoc == null)
            {
                return HttpNotFound();
            }
            return View(tOPDoc);
        }

        // GET: TOPDocs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TOPDocs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDocumentTypeProvider,NameDocument")] TOPDoc tOPDoc)
        {
            if (ModelState.IsValid)
            {
                db.TypeOfPurchaseDocument.Add(tOPDoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tOPDoc);
        }

        // GET: TOPDocs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TOPDoc tOPDoc = db.TypeOfPurchaseDocument.Find(id);
            if (tOPDoc == null)
            {
                return HttpNotFound();
            }
            return View(tOPDoc);
        }

        // POST: TOPDocs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDocumentTypeProvider,NameDocument")] TOPDoc tOPDoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tOPDoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tOPDoc);
        }

        // GET: TOPDocs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TOPDoc tOPDoc = db.TypeOfPurchaseDocument.Find(id);
            if (tOPDoc == null)
            {
                return HttpNotFound();
            }
            return View(tOPDoc);
        }

        // POST: TOPDocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TOPDoc tOPDoc = db.TypeOfPurchaseDocument.Find(id);
            db.TypeOfPurchaseDocument.Remove(tOPDoc);
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

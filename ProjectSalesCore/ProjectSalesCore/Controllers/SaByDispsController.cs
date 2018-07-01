// <copyright file="SaByDispsController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ProjectSalesCore.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using CSales.Database.Contexts;
    using CSales.Database.Models;
    using ProjectSalesCore.ViewModel.SaleByDispatch;
    using System;

    public class SaByDispsController : Controller
    {
        private MyContext db = new MyContext();

        // GET: SaByDisps
        public ActionResult Index()
        {
            return View(db.SalesByDispatch.ToList());
        }

        // GET: SaByDisps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SaByDisp saByDisp = db.SalesByDispatch.Find(id);
            if (saByDisp == null)
            {
                return HttpNotFound();
            }

            return View(saByDisp);
        }

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaByDisp saByDisp = db.SalesByDispatch.Find(id);
            if (saByDisp == null)
            {
                return HttpNotFound();
            }
            return View(saByDisp);
        }

        // POST: SaByDisps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SaByDisp saByDisp = db.SalesByDispatch.Find(id);
            db.SalesByDispatch.Remove(saByDisp);
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

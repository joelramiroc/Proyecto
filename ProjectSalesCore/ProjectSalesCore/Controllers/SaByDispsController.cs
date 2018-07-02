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
    using ProjectSalesCore.ViewModel;
    using System.Collections.Generic;
    using ProjectSalesCore.ViewModel.SaleOrder;

    public class SaByDispsController : Controller
    {
        private MyContext db = new MyContext();

        // GET: SaByDisps
        public ActionResult Index()
        {
            var sales = this.db.SalesByDispatch.ToList();
            var list = new List<SaleBDIndexViewModel>();

            foreach (var item in sales)
            {
                var total = this.db.OrderDetailsVentas.Where(o => o.IdSaleOrder == item.IdSaleOrder).Sum(o => o.Total);

                var cvm = new SaleBDIndexViewModel
                {
                    TotalAmont = total,
                    ClientName = item.SaleOrder.Client.Name,
                    CreatedDate = item.CreatedDate,
                    EmployeeName = item.Employee.Name,
                    IdSaleOrder = item.IdSaleOrder,
                    Id = item.Id
                };
                list.Add(cvm);
            }

            return View(list);
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
            SaleOrder saleOrder = db.SaleOrder.Find(saByDisp.IdSaleOrder);
            if (saleOrder == null)
            {
                return HttpNotFound();
            }

            var odv = this.db.OrderDetailsVentas.Where(v => v.IdSaleOrder == saleOrder.IdSaleOrder).ToList();

            var total = odv.Sum(o => o.Total);

            var show = new DetailSaleBDispatchViewModel
            {
                CreatedDate = saleOrder.CreatedDate,
                DetailVentas = odv,
                EmployeeName = saByDisp.Employee?.Name,
                Id = saleOrder.IdSaleOrder,
                ClientName = saleOrder.Client?.Name,
                TotalAmount = total
            };

            return View(show);
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

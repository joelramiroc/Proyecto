// <copyright file="CounterSalesController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ProjectSalesCore.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using CSales.Database.Contexts;
    using CSales.Database.Models;
    using ProjectSalesCore.ViewModel.SaleByDispatch;
    using System.Collections.Generic;
    using ProjectSalesCore.ViewModel.SaleOrder;

    public class CounterSalesController : Controller
    {
        private MyContext db = new MyContext();

        // GET: CounterSales
        public ActionResult Index()
        {
            var sales = this.db.CounterSale.ToList();
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
            SaleOrder saleOrder = db.SaleOrder.Find(counterSale.IdSaleOrder);
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
                EmployeeName = counterSale.Employee?.Name,
                Id = saleOrder.IdSaleOrder,
                ClientName = saleOrder.Client?.Name,
                TotalAmount = total
            };

            return View(show);
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

// <copyright file="SaleOrdersController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ProjectSalesCore.Controllers
{
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using CSales.Database.Contexts;
    using CSales.Database.Models;
    using ProjectSalesCore.DataBase.Models;
    using ProjectSalesCore.ViewModel.SaleOrder;

    public enum TypeSale
    {
        Dispatch = 1,
        Counter = 2
    }

    public class SaleOrdersController : Controller
    {
        private MyContext db = new MyContext();

        // GET: SaleOrders
        public ActionResult Index()
        {
            var saleOrder = this.db.SaleOrder.Include(s => s.Client).Include(s => s.Employee).Include(s => s.PaymentCondition);
            return this.View(saleOrder.ToList());
        }

        // GET: SaleOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SaleOrder saleOrder = db.SaleOrder.Find(id);
            if (saleOrder == null)
            {
                return HttpNotFound();
            }

            var odv = this.db.OrderDetailsVentas.Where(v => v.IdSaleOrder == saleOrder.IdSaleOrder).ToList();

            var total = odv.Sum( o => o.Total);

            var show = new DetailSaleBDispatchViewModel
            {
                CreatedDate = saleOrder.CreatedDate,
                DetailVentas = odv,
                EmployeeName = saleOrder.Employee?.Name,
                Id = saleOrder.IdSaleOrder,
                ClientName = saleOrder.Client?.Name,
                TotalAmount = total
            };

            return View(show);
        }

        public ActionResult SelectStorage()
        {
            this.ViewBag.IdStorage = new SelectList(db.Storage, "IdStorage", "StorageName");
            return View();
        }

        public ActionResult SaleByDispatchs(int id)
        {
            var so = this.db.SaleOrder.Find(id);
            var od = this.db.OrderDetailsVentas.Where(sss => sss.IdSaleOrder == id).ToList();

            foreach (var item in od)
            {
                var ii = this.db.ExternalInventory.Where(i => i.IdStorage == so.IdStorage && i.IdEProduct == item.IdExternalProduct).FirstOrDefault();
                if (ii != null && ii.Quantity <= item.Quantity)
                {
                    return this.RedirectToAction("Index");
                }
            }

            var s = new CreateSBDispatchViewModel();
            s.idSaleOrder = id;

            var directions = from TypeSale d in Enum.GetValues(typeof(TypeSale))
                             select new { ID = (int)d, Name = d.ToString() };

            this.ViewBag.TypeSale = new SelectList(directions, "Id", "Name", s.TypeSale);

            this.ViewBag.IdEmployee = new SelectList(db.Employee, "Id", "Name");
            this.ViewBag.IdCurrentAccountDocumentType = new SelectList(db.CurrentAccountDocumentType, "IdCurrentAccountDocumentType", "TypeName", s.IdCurrentAccountDocumentType);
            return this.View("SaleByDispatch", s);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaleByDispatch(CreateSBDispatchViewModel model)
        {
            var sl = this.db.SaleOrder.Find(model.idSaleOrder);
            var idt = 0;
            if (model.TypeSale == 1)
            {
                var sbd = new SaByDisp
                {
                    CreatedDate = DateTime.Now,
                    IdSaleOrder = model.idSaleOrder,
                    IdEmployee = model.IdEmployee,
                    itsPaid = model.ItsPaid
                };

                var r = this.db.SalesByDispatch.Add(sbd);
                this.db.SaveChanges();
                idt = r.Id;
            }
            else
            {
                var sbd = new CounterSale
                {
                    CreatedDate = DateTime.Now,
                    IdSaleOrder = model.idSaleOrder,
                    IdEmployee = model.IdEmployee,
                    itsPaid = model.ItsPaid
                };

                var r = this.db.CounterSale.Add(sbd);
                this.db.SaveChanges();
                idt = r.Id;
            }

            var total = this.db.OrderDetailsVentas.Where(o => o.IdSaleOrder == sl.IdSaleOrder).Sum(s => s.Total);

            if (!model.ItsPaid)
            {
                var cac = this.db.CustomerCheckingAccount.Where(c => c.IdClient == sl.IdClient).FirstOrDefault();
                cac.TotalDebt += total;
                db.Entry(cac).State = EntityState.Modified;
                db.SaveChanges();
            }

            var bill = new Bill
            {
                CreatedDate = DateTime.Now,
                IdClient = sl.IdClient,
                IdCurrentActualDocumentType = model.IdCurrentAccountDocumentType,
                IdEmployee = model.IdEmployee,
                Total = total,
            };

            if (model.TypeSale == 1)
            {
                bill.IdSaleByDispatch = idt;
            }
            else
            {
                bill.IdCounterSale = idt;
            }

            var b = this.db.Bill.Add(bill);
            this.db.SaveChanges();

            var reason = 0;

            if (model.TypeSale == 1)
            {
                reason = this.db.ReasonNote.Where(r => r.ReasonName.Equals("SALE BY DISPATCH")).FirstOrDefault().IdReasonEntryNote;
            }
            else
            {
                reason = this.db.ReasonNote.Where(r => r.ReasonName.Equals("COUNTER SALE")).FirstOrDefault().IdReasonEntryNote;
            }

            var oN = new OutputNote
            {
                IdBill = b.IdBill,
             IdReasonNote = reason,
             IdSaleOrder = model.idSaleOrder,
             CreatedDate = DateTime.Now
            };

            this.db.OuputNote.Add(oN);
            this.db.SaveChanges();

            var od = this.db.OrderDetailsVentas.Where(sss => sss.IdSaleOrder == model.idSaleOrder).ToList();
            var so = this.db.SaleOrder.Find(model.idSaleOrder);
            foreach (var item in od)
            {
                var ii = this.db.ExternalInventory.Where(i => i.IdStorage == so.IdStorage && i.IdEProduct == item.IdExternalProduct).FirstOrDefault();
                ii.Quantity -= item.Quantity;
                db.Entry(ii).State = EntityState.Modified;
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SelectStorage(SelectStorage model)
        {
            return this.Create(model.IdStorage);
        }

        // GET: SaleOrders/Create
        public ActionResult Create(int idStorage)
        {
            this.ViewBag.IdClient = new SelectList(db.Client, "Id", "Name");
            this.ViewBag.IdEmployee = new SelectList(db.Employee, "Id", "Name");
            this.ViewBag.IdPaymentCondition = new SelectList(this.db.PaymentCondition, "IdPaymentCondition", "ConditionName");
            var show = new CreateSaleOrderViewModel();
            show.Products = this.db.ExternalInventory.Where(eI => eI.IdStorage == idStorage);
            show.IdStorage = idStorage;
            return this.View("Create",show);
        }

        // POST: SaleOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateSaleOrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in model.OrderDetailsCompras)
                {
                    var eI = this.db.ExternalInventory.Where(i => i.ProductDescription == item.Description).FirstOrDefault();
                    if (eI != null && eI.Quantity > item.Quantity)
                    {
                        return this.View("Create",model);
                    }
                }

                    var sor = new SaleOrder
                {
                    IdClient = model.IdClient,
                    IdStorage = model.IdStorage,
                    CreatedDate = DateTime.Now,
                    IdEmployee = model.IdEmployee,
                    IdPaymentCondition = model.IdPaymentCondition,
                };
                var nso = this.db.SaleOrder.Add(sor);
                this.db.SaveChanges();
                foreach (var item in model.OrderDetailsCompras)
                {
                    var iInv = this.db.ExternalInventory.Find(item.IdProduct);
                    decimal total = item.Quantity * iInv.UnitPrice;

                    if (iInv.DiscountRate != 0)
                    {
                        decimal disc = (decimal)(iInv.DiscountRate / (decimal)100.000);
                        var rest = (item.Quantity * iInv.UnitPrice) * disc;
                        var t = (item.Quantity * iInv.UnitPrice) - rest;
                        total += t;
                    }

                    var nde = new OrderDetailsVentas
                    {
                        DiscountRate = item.Discount,
                        IdExternalProduct = item.IdProduct,
                        IdSaleOrder = nso.IdSaleOrder,
                        Quantity = item.Quantity,
                        UnitPrice = iInv.UnitPrice,
                        Total = total
                    };
                    this.db.OrderDetailsVentas.Add(nde);
                    this.db.SaveChanges();
                }

                return this.RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        // GET: SaleOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleOrder saleOrder = db.SaleOrder.Find(id);
            if (saleOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdClient = new SelectList(db.Client, "Id", "Name", saleOrder.IdClient);
            ViewBag.IdEmployee = new SelectList(db.Employee, "Id", "Name", saleOrder.IdEmployee);
            ViewBag.IdPaymentCondition = new SelectList(db.PaymentCondition, "IdPaymentCondition", "ConditionName", saleOrder.IdPaymentCondition);
            return View(saleOrder);
        }

        // POST: SaleOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdSaleOrder,CreatedDate,IdClient,IdEmployee,IdPaymentCondition")] SaleOrder saleOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(saleOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdClient = new SelectList(db.Client, "Id", "Name", saleOrder.IdClient);
            ViewBag.IdEmployee = new SelectList(db.Employee, "Id", "Name", saleOrder.IdEmployee);
            ViewBag.IdPaymentCondition = new SelectList(db.PaymentCondition, "IdPaymentCondition", "ConditionName", saleOrder.IdPaymentCondition);
            return View(saleOrder);
        }

        // GET: SaleOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleOrder saleOrder = db.SaleOrder.Find(id);
            if (saleOrder == null)
            {
                return HttpNotFound();
            }
            return View(saleOrder);
        }

        // POST: SaleOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SaleOrder saleOrder = db.SaleOrder.Find(id);
            db.SaleOrder.Remove(saleOrder);
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

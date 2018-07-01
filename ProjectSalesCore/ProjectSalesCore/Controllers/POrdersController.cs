// <copyright file="POrdersController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ProjectSalesCore.Controllers
{
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
    using ProjectSalesCore.DataBase.Models;
    using ProjectSalesCore.ViewModel.PurchaseOrder;

    public class POrdersController : Controller
    {
        private MyContext db = new MyContext();

        // GET: POrders
        public ActionResult Index()
        {
            var purchaseOrder = db.PurchaseOrder.Include(p => p.Provider);
            return View(purchaseOrder.ToList());
        }

        // GET: POrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            POrder pOrder = db.PurchaseOrder.Find(id);
            var list = this.db.OrderDetailsCompras.Where(od => od.PurchaseNumber == pOrder.PurchaseNumber).ToList();

            var nList = new List<DetailsOrderDetailViewModel>();
            decimal total = 0;
            foreach (var item in list)
            {
                var nE = new DetailsOrderDetailViewModel();
                nE.Discount = item.Discount.Value;
                nE.ProductName = item.Product.ProductName;
                nE.Quantity = item.Quantity;
                nE.TotalAmount = item.TotalAmount;
                nE.UnitPrice = item.UnitPrice;
                total += item.TotalAmount;
                nList.Add(nE);
                nE.IsInternalPurchase = item.POrder.IsInternalPurchase;
            }

            var Show = new POrderDetail
            {
                DetailsOrderDetailViewModels = nList,
                PurchaseNumber = pOrder.PurchaseNumber,
                PaymentCondition = this.db.PaymentCondition.Find(pOrder.IdPaymentCondition).ConditionName,
                ProviderName = this.db.Provider.Find(pOrder.IdProvider).Name,
                CreatedDate = pOrder.CreatedDate,
                PlaceOfEntry = pOrder.PlaceOfEntry,
                TotalAmount = total,
                StatusOrder = this.db.StatusOrder.Find(pOrder.IdStatusOrder).StatusName,
                IsInternalPurchase = pOrder.IsInternalPurchase
            };

            if (pOrder == null)
            {
                return HttpNotFound();
            }
            return View(Show);
        }

        public ActionResult CreateSelectType()
        {
            return View();
        }

        // GET: POrders/Create
        public ActionResult Create()
        {

            ViewBag.IdCostCenter = new SelectList(db.CostCenter, "Id", "CostName");
            return this.View();
        }

        // POST: POrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SelectTypeOfPurchaseViewModel selectTypeOfPurchaseViewModel)
        {
            if (ModelState.IsValid)
            {
                var costCenter = this.db.CostCenter.Find(selectTypeOfPurchaseViewModel.IdCostCenter);
                if (costCenter.CostName.Equals("INTERNAL"))
                {
                    return this.PurchaseOrderInternal();
                }
                else
                {
                    return this.PurchaseOrderExternal();
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult PurchaseOrderInternal()
        {
            ViewBag.IdProvider = new SelectList(db.Provider, "Id", "Name");
            ViewBag.IdStatusOrder = new SelectList(db.StatusOrder, "IdStatusOrder", "StatusName");
            ViewBag.IdStorage = new SelectList(db.Storage, "IdStorage", "StorageName");
            ViewBag.IdPaymentCondition = new SelectList(db.PaymentCondition, "IdPaymentCondition", "ConditionName");
            var t = new CreatePOrderInternal();
            t.OrderDetailsCompras = new List<POrderInternalDetail>();
            t.Products = this.db.Product;
            return View("PurchaseOrderInternal", t);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PurchaseOrderInternal(CreatePOrderInternal pOrder)
        {
            this.db.Database.ExecuteSqlCommand(@"INSERT INTO PORDER(PLACEOFENTRY,IDPROVIDER,CREATEDDATE,IDPC,IDSO,ISIP,ISTOR) values ({0},{1},{2},{3},{4},{5},{6})", pOrder.PlaceOfEntry, pOrder.IdProvider, DateTime.Now, pOrder.IdPaymentCondition, pOrder.IdStatusOrder, true, pOrder.IdStorage);
            var ordenG = this.db.PurchaseOrder.OrderByDescending(x => x.PurchaseNumber).FirstOrDefault();

            foreach (var item in pOrder.OrderDetailsCompras)
            {
                var n = new OrderDetailsCompras
                {
                    Description = item.Description,
                    Discount = item.Discount,
                    IdProduct = item.IdProduct,
                    UnitPrice = item.UnitPrice,
                    PurchaseNumber = ordenG.PurchaseNumber,
                    Quantity = item.Quantity,
                    TotalAmount = item.UnitPrice * item.Quantity
                };
                this.db.OrderDetailsCompras.Add(n);
                this.db.SaveChanges();
            }

            var state = this.db.StatusOrder.Find(pOrder.IdStatusOrder);
            if (state.StatusName.Equals("RECIBIDO"))
            {
                pOrder.PurchaseNumber = ordenG.PurchaseNumber;
                var storage = this.db.Storage.Find(pOrder.IdStorage);
                foreach (var item in pOrder.OrderDetailsCompras)
                {
                    var result = this.db.ExternalInventory.Where(i => i.ProductDescription.Equals(item.Description) && i.UnitPrice == item.UnitPrice).FirstOrDefault();
                    if (result != null)
                    {
                        result.Quantity += item.Quantity;
                        db.Entry(result).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        this.db.Database.ExecuteSqlCommand(@"INSERT INTO IPDCT(IDPRODUCT,PRODUCTDESCRIPTION,ACTIVE) values ({0},{1},{2})", item.IdProduct, item.Description, true);
                        var nuevoP = this.db.InternalProduct.OrderByDescending(x => x.Id).FirstOrDefault();
                        var inventory = new InternalInventory
                        {
                            IdIProduct = nuevoP.Id,
                            IdStorage = storage.IdStorage,
                            ProductDescription = item.Description,
                            Quantity = item.Quantity,
                        };
                        this.db.InternalInventory.Add(inventory);
                        this.db.SaveChanges();
                    }
                }

                return CreatePOrder(ordenG.PurchaseNumber);
            }

            return RedirectToAction("Index");
        }

        public ActionResult PurchaseOrderExternal()
        {
            ViewBag.IdProvider = new SelectList(db.Provider, "Id", "Name");
            ViewBag.IdStatusOrder = new SelectList(db.StatusOrder, "IdStatusOrder", "StatusName");
            ViewBag.IdStorage = new SelectList(db.Storage, "IdStorage", "StorageName");
            ViewBag.IdPaymentCondition = new SelectList(db.PaymentCondition, "IdPaymentCondition", "ConditionName");
            var t = new CreatePOrderExternal();
            t.OrderDetailsCompras = new List<POrderExternalDetail>();
            t.Products = this.db.Product;
            return View("PurchaseOrderExternal", t);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PurchaseOrderExternal(CreatePOrderExternal pOrder)
        {
            this.db.Database.ExecuteSqlCommand(@"INSERT INTO PORDER(PLACEOFENTRY,IDPROVIDER,CREATEDDATE,IDPC,IDSO,ISIP,ISTOR) values ({0},{1},{2},{3},{4},{5},{6})", pOrder.PlaceOfEntry, pOrder.IdProvider, DateTime.Now, pOrder.IdPaymentCondition, pOrder.IdStatusOrder, false, pOrder.IdStorage);
            var ordenG = this.db.PurchaseOrder.OrderByDescending(x => x.PurchaseNumber).FirstOrDefault();

            foreach (var item in pOrder.OrderDetailsCompras)
            {
                decimal total = 0;
                if (item.Discount == 0)
                {
                    total = item.UnitPrice * item.Quantity;
                }
                else
                {
                    decimal disc = (decimal)(item.Discount / (decimal)100.000);
                    var rest = (item.Quantity * item.UnitPrice) * disc;
                    var t = (item.Quantity * item.UnitPrice) - rest;
                    total += t;
                }

                var n = new OrderDetailsCompras
                {
                    Description = item.Description,
                    Discount = item.Discount,
                    IdProduct = item.IdProduct,
                    UnitPrice = item.UnitPrice,
                    PurchaseNumber = ordenG.PurchaseNumber,
                    Quantity = item.Quantity,
                    TotalAmount = total
                };
                this.db.OrderDetailsCompras.Add(n);
                this.db.SaveChanges();
            }

            var state = this.db.StatusOrder.Find(pOrder.IdStatusOrder);
            if (state.StatusName.Equals("RECIBIDO"))
            {
                pOrder.PurchaseNumber = ordenG.PurchaseNumber;
                var storage = this.db.Storage.Find(pOrder.IdStorage);
                foreach (var item in pOrder.OrderDetailsCompras)
                {
                    var result = this.db.ExternalInventory.Where(i => i.ProductDescription.Equals(item.Description) && i.UnitPrice == item.UnitPrice).FirstOrDefault();
                    if (result != null)
                    {
                        result.Quantity += item.Quantity;
                        db.Entry(result).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        this.db.Database.ExecuteSqlCommand(@"INSERT INTO EP(IDPRODUCT,PRODUCTDESCRIPTION,ACTIVE) values ({0},{1},{2})", item.IdProduct, item.Description, true);
                        var nuevoP = this.db.ExternalProduct.OrderByDescending(x => x.Id).FirstOrDefault();

                        var inventory = new ExternalInventory
                        {
                            IdEProduct = nuevoP.Id,
                            DiscountRate = 0,
                            IdStorage = storage.IdStorage,
                            MaximumStock = 100,
                            MinimumStock = 10,
                            ProductDescription = item.Description,
                            Quantity = item.Quantity,
                            UnitPrice = item.UnitPrice
                        };
                        this.db.ExternalInventory.Add(inventory);
                        this.db.SaveChanges();
                    }
                }

                return CreatePOrder(ordenG.PurchaseNumber);
            }

            return RedirectToAction("Index");
        }

        public ActionResult CreatePOrder(int porder)
        {
            var show = new PDocsViewModel();
            show.idPDoc = porder;
            this.ViewBag.IdCurrentAccountDocumentType = new SelectList(db.CurrentAccountDocumentType, "IdCurrentAccountDocumentType", "TypeName", show.IdCurrentAccountDocumentType);
            return View("CreatePOrder", show);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePOrder(PDocsViewModel model)
        {
            var porder = this.db.PurchaseOrder.Find(model.idPDoc);

            var c = this.db.OrderDetailsCompras.Where(p => p.PurchaseNumber == porder.PurchaseNumber).ToList();
            decimal total = c.Sum(cc => cc.TotalAmount);

            var pdoc = new PDoc
            {
                CreatedDate = DateTime.Now,
                IdCurrentAccountDocumentType = model.IdCurrentAccountDocumentType,
                IsWithOrder = true,
                IdProvider = porder.IdProvider,
                PurchaseNumber = porder.PurchaseNumber,
                TotalAmount = total,
                ItsPaid = model.ItsPaid,
            };

            this.db.Database.ExecuteSqlCommand(@"INSERT INTO PDOC(PROVIDER,IDDT,CREATEDDATE,TOTALAMOUNT,ISWITHORDER,ITSPAID,PN) values ({0},{1},{2},{3},{4},{5},{6})", pdoc.IdProvider, pdoc.IdCurrentAccountDocumentType, DateTime.Now, pdoc.TotalAmount, pdoc.IsWithOrder, pdoc.ItsPaid, model.idPDoc);

            if (!pdoc.ItsPaid)
            {
                var p = this.db.CurrentAcountProvider.Find(pdoc.IdProvider);
                p.TotalDebt += pdoc.TotalAmount;
                db.Entry(p).State = EntityState.Modified;
                db.SaveChanges();
            }
            return this.RedirectToAction("Index");
        }

        // GET: POrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            POrder pOrder = this.db.PurchaseOrder.Find(id);
            if (pOrder == null)
            {
                return this.HttpNotFound();
            }

            if (pOrder.StatusOrder.StatusName.Equals("RECIBIDO"))
            {
                return RedirectToAction("Index");
            }

            this.ViewBag.IdProvider = new SelectList(db.Provider, "Id", "Name", pOrder.IdProvider);
            this.ViewBag.IdPaymentCondition = new SelectList(db.PaymentCondition, "IdPaymentCondition", "ConditionName");
            this.ViewBag.IdStatusOrder = new SelectList(db.StatusOrder, "IdStatusOrder", "StatusName");
            return this.View(pOrder);
        }

        // POST: POrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(POrder po)
        {
            if (ModelState.IsValid)
            {
                var ordenG = this.db.PurchaseOrder.Find(po.PurchaseNumber);
                ordenG.IdPaymentCondition = po.IdPaymentCondition;
                ordenG.IdProvider = po.IdProvider;
                ordenG.IdStatusOrder = po.IdStatusOrder;
                db.Entry(ordenG).State = EntityState.Modified;
                db.SaveChanges();

                var state = this.db.StatusOrder.Find(ordenG.IdStatusOrder);

                if (state.StatusName.Equals("RECIBIDO"))
                {
                    var storage = this.db.Storage.Find(ordenG.IdStorage);

                    var pOrder = this.db.OrderDetailsCompras.Where(od => od.PurchaseNumber == ordenG.PurchaseNumber).ToList();
                    if (ordenG.IsInternalPurchase)
                    {
                        foreach (var item in pOrder)
                        {
                            var result = this.db.ExternalInventory.Where(i => i.ProductDescription.Equals(item.Description) && i.UnitPrice == item.UnitPrice).FirstOrDefault();
                            if (result != null)
                            {
                                result.Quantity += item.Quantity;
                                db.Entry(result).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                            else
                            {
                                this.db.Database.ExecuteSqlCommand(@"INSERT INTO IPDCT(IDPRODUCT,PRODUCTDESCRIPTION,ACTIVE) values ({0},{1},{2})", item.IdProduct, item.Description, true);
                                var nuevoP = this.db.InternalProduct.OrderByDescending(x => x.Id).FirstOrDefault();

                                var inventory = new InternalInventory
                                {
                                    IdIProduct = nuevoP.Id,
                                    IdStorage = storage.IdStorage,
                                    ProductDescription = item.Description,
                                    Quantity = item.Quantity,
                                };
                                this.db.InternalInventory.Add(inventory);
                                this.db.SaveChanges();
                            }
                        }
                    }
                    else
                    {
                        foreach (var item in pOrder)
                        {
                            var result = this.db.ExternalInventory.Where(i => i.ProductDescription.Equals(item.Description) && i.UnitPrice == item.UnitPrice).FirstOrDefault();
                            if (result != null)
                            {
                                result.Quantity += item.Quantity;
                                db.Entry(result).State = EntityState.Modified;
                                db.SaveChanges();
                            }
                            else
                            {

                                this.db.Database.ExecuteSqlCommand(@"INSERT INTO EP(IDPRODUCT,PRODUCTDESCRIPTION,ACTIVE) values ({0},{1},{2})", item.IdProduct, item.Description, true);
                                var nuevoP = this.db.ExternalProduct.OrderByDescending(x => x.Id).FirstOrDefault();

                                var inventory = new ExternalInventory
                                {
                                    IdEProduct = nuevoP.Id,
                                    DiscountRate = 0,
                                    IdStorage = storage.IdStorage,
                                    MaximumStock = 100,
                                    MinimumStock = 10,
                                    ProductDescription = item.Description,
                                    Quantity = item.Quantity,
                                    UnitPrice = item.UnitPrice
                                };
                                this.db.ExternalInventory.Add(inventory);
                                this.db.SaveChanges();
                            }
                        }
                    }

                    return this.CreatePOrder(po.PurchaseNumber);
                }

                return this.RedirectToAction("Index");
            }

            ViewBag.IdProvider = new SelectList(db.Provider, "Id", "Name");
            ViewBag.IdPaymentCondition = new SelectList(db.PaymentCondition, "IdPaymentCondition", "ConditionName");
            ViewBag.IdStatusOrder = new SelectList(db.StatusOrder, "IdStatusOrder", "StatusName");
            return RedirectToAction("Index");
        }

        // GET: POrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POrder pOrder = db.PurchaseOrder.Find(id);
            if (pOrder == null)
            {
                return HttpNotFound();
            }
            return View(pOrder);
        }

        // POST: POrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            POrder pOrder = db.PurchaseOrder.Find(id);
            db.PurchaseOrder.Remove(pOrder);
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

        public PartialViewResult BlankEditorRow()
        {
            return PartialView("GiftEditorRow", new OrderDetailsComprasViewModel());
        }
    }
}

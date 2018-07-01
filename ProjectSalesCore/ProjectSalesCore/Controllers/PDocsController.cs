// <copyright file="PDocsController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ProjectSalesCore.Controllers
{
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using CSales.Database.Contexts;
    using CSales.Database.Models;
    using ProjectSalesCore.ViewModel.PDocs;

    public class PDocsController : Controller
    {
        private MyContext db = new MyContext();

        // GET: PDocs
        public ActionResult Index()
        {
            var purchaseDocument = db.PurchaseDocument.Include(p => p.CurrentAccountDocumentType).Include(p => p.Provider).Include(p => p.PurchaseDocument);
            return this.View(purchaseDocument.ToList());
        }

        public ActionResult TypePurchase()
        {
            this.ViewBag.IdCostCenter = new SelectList(db.CostCenter, "Id", "CostName");
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TypePurchase(TypePurchase model)
        {
            var cs = this.db.CostCenter.Find(model.IdCostCenter);
            if (cs.CostName.Equals("INTERNAL"))
            {
                return this.CreateInternal();
            }
            else
            {
                return this.Create();
            }

            return this.RedirectToAction("Index");
        }

        public ActionResult CreateInternal()
        {
            var show = new CreatePOrderInternal();
            this.ViewBag.IdProvider = new SelectList(db.Provider, "Id", "Name");
            this.ViewBag.IdStorage = new SelectList(db.Storage, "IdStorage", "StorageName");
            this.ViewBag.IdCurrentAccountDocumentType = new SelectList(db.CurrentAccountDocumentType, "IdCurrentAccountDocumentType", "TypeName", show.IdCurrentAccountDocumentType);
            show.Products = this.db.Product;
            return this.View("CreateInternal", show);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateInternal(CreatePOrderInternal viewModel)
        {

            if (this.ModelState.IsValid)
            {
                decimal total = 0;
                foreach (var item in viewModel.OrderDetailsCompras)
                {
                    if (item.Discount == 0)
                    {
                        total += item.Quantity * item.UnitPrice;
                    }
                    else
                    {
                        decimal disc = (decimal)(item.Discount / 100.000);
                        var rest = (item.Quantity * item.UnitPrice) * disc;
                        var t = (item.Quantity * item.UnitPrice) - rest;
                        total += t;
                    }
                }

                var model = new PDoc
                {
                    CreatedDate = DateTime.Now,
                    IdCurrentAccountDocumentType = viewModel.IdCurrentAccountDocumentType,
                    IdProvider = viewModel.IdProvider,
                    IsWithOrder = false,
                    ItsPaid = viewModel.ItsPaid,
                    TotalAmount = total,
                };

                this.db.Database.ExecuteSqlCommand(@"INSERT INTO PDOC(PROVIDER,IDDT,CREATEDDATE,TOTALAMOUNT,ISWITHORDER,ITSPAID) values ({0},{1},{2},{3},{4},{5})", model.IdProvider, model.IdCurrentAccountDocumentType, DateTime.Now, model.TotalAmount, model.IsWithOrder, model.ItsPaid);
                var newPDoc = this.db.PurchaseDocument.ToList().OrderByDescending(x => x.Id).FirstOrDefault();

                foreach (var item in viewModel.OrderDetailsCompras)
                {
                    decimal t = 0;
                    if (item.Discount == 0)
                    {
                        t = item.UnitPrice * item.Quantity;
                    }
                    else
                    {
                        decimal disc = (decimal)(item.Discount / (decimal)100.000);
                        var rest = (item.Quantity * item.UnitPrice) * disc;
                        var ts = (item.Quantity * item.UnitPrice) - rest;
                        t += ts;
                    }

                    var norder = new DPToSale
                    {
                        Description = item.Description,
                        Discount = item.Discount,
                        IdProduct = item.IdProduct,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice,
                        TotalAmount = t,
                        IdPDoc = newPDoc.Id
                    };

                    this.db.DetailsProductsToSale.Add(norder);
                    this.db.SaveChanges();

                    var niI = this.db.InternalProduct.Where(i => i.IdProduct == item.IdProduct).FirstOrDefault();

                    InternalInventory iI = null;

                    if (niI != null)
                    {
                        iI = this.db.InternalInventory.Where(i => i.IdStorage == viewModel.IdStorage && i.IdIProduct == niI.Id && i.ProductDescription.Equals(item.Description)).FirstOrDefault();
                    }

                    //AQUI FALTA VALIDAR SI ES EN ESE STORAGE QUE EXISTE DICHO RODUCTO
                    if (iI == null)
                    {
                        niI = new IProduct();
                        niI.Active = true;
                        niI.IdProduct = item.IdProduct;
                        niI.ProductDescription = item.Description;

                        this.db.Database.ExecuteSqlCommand(@"INSERT INTO IPDCT(IDPRODUCT,PRODUCTDESCRIPTION,ACTIVE) values ({0},{1},{2})",niI.IdProduct, niI.ProductDescription,niI.Active );
                        var nP = this.db.InternalProduct.OrderByDescending(x => x.Id).FirstOrDefault();

                        var inventory = new InternalInventory
                        {
                            IdIProduct = nP.Id,
                            IdStorage = viewModel.IdStorage,
                            ProductDescription = nP.ProductDescription,
                            Quantity = item.Quantity,
                        };

                        this.db.InternalInventory.Add(inventory);
                        this.db.SaveChanges();
                    }
                    else
                    {
                        iI.Quantity += item.Quantity;
                        this.db.InternalInventory.Add(iI);
                        this.db.SaveChanges();
                    }

                }

                if (!model.ItsPaid)
                {
                    var curraprovi = this.db.CurrentAcountProvider.Find(model.IdProvider);
                    curraprovi.TotalDebt += model.TotalAmount;
                    this.db.Entry(curraprovi).State = EntityState.Modified;
                    this.db.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        // GET: PDocs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PDoc pDoc = db.PurchaseDocument.Find(id);
            if (pDoc == null)
            {
                return HttpNotFound();
            }

            return this.View(pDoc);
        }

        // GET: PDocs/Create
        public ActionResult Create()
        {
            ViewBag.IdStorage = new SelectList(db.Storage, "IdStorage", "StorageName");
            ViewBag.IdProvider = new SelectList(db.Provider, "Id", "Name");
            var show = new CreateDocWithoutPurchaseDoc();
            ViewBag.IdCurrentAccountDocumentType = new SelectList(db.CurrentAccountDocumentType, "IdCurrentAccountDocumentType", "TypeName", show.IdCurrentAccountDocumentType);
            show.Products = this.db.Product;
            return View("Create", show);
        }

        // POST: PDocs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateDocWithoutPurchaseDoc viewModel)
        {
            if (this.ModelState.IsValid)
            {
                decimal total = 0;
                foreach (var item in viewModel.OrderDetailsCompras)
                {
                    if (item.Discount == 0)
                    {
                        total += item.Quantity * item.UnitPrice;
                    }
                    else
                    {
                        decimal disc = (decimal)(item.Discount / (decimal)100.000);
                        var rest = (item.Quantity * item.UnitPrice) * disc;
                        var t = (item.Quantity * item.UnitPrice) - rest;
                        total += t;
                    }
                }

                var model = new PDoc
                {
                    CreatedDate = DateTime.Now,
                    IdCurrentAccountDocumentType = viewModel.IdCurrentAccountDocumentType,
                    IdProvider = viewModel.IdProvider,
                    IsWithOrder = false,
                    ItsPaid = viewModel.ItsPaid,
                    TotalAmount = total,
                };

                this.db.Database.ExecuteSqlCommand(@"INSERT INTO PDOC(PROVIDER,IDDT,CREATEDDATE,TOTALAMOUNT,ISWITHORDER,ITSPAID) values ({0},{1},{2},{3},{4},{5})", model.IdProvider, model.IdCurrentAccountDocumentType, DateTime.Now, model.TotalAmount, model.IsWithOrder, model.ItsPaid);
                var newPDoc = this.db.PurchaseDocument.ToList().OrderByDescending(x => x.Id).FirstOrDefault();

                foreach (var item in viewModel.OrderDetailsCompras)
                {
                    decimal t = 0;
                    if (item.Discount == 0)
                    {
                        t = item.UnitPrice * item.Quantity;
                    }
                    else
                    {
                        decimal disc = (decimal)(item.Discount / (decimal)100.000);
                        var rest = (item.Quantity * item.UnitPrice) * disc;
                        var ts = (item.Quantity * item.UnitPrice) - rest;
                        t += ts;
                    }

                    var norder = new DPToSale
                    {
                        Description = item.Description,
                        Discount = item.Discount,
                        IdProduct = item.IdProduct,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice,
                        TotalAmount = t,
                        IdPDoc = newPDoc.Id
                    };

                    this.db.DetailsProductsToSale.Add(norder);
                    this.db.SaveChanges();

                    var ep = this.db.ExternalProduct.Where(e => e.IdProduct == item.IdProduct).FirstOrDefault();
                    ExternalInventory eI = null;

                    if (ep != null)
                    {
                        eI = this.db.ExternalInventory.Where(e => e.IdEProduct == ep.Id && e.ProductDescription.Equals(item.Description) && e.IdStorage == viewModel.IdStorage).FirstOrDefault();
                    }

                    if (eI == null)
                    {
                        var inventory = new ExternalInventory
                        {
                            IdEProduct = item.Id,
                            DiscountRate = 0,
                            IdStorage = viewModel.IdStorage,
                            MaximumStock = 100,
                            MinimumStock = 10,
                            ProductDescription = item.Description,
                            Quantity = item.Quantity,
                            UnitPrice = item.UnitPrice
                        };
                    }
                    else
                    {
                        eI.Quantity += item.Quantity;
                        this.db.ExternalInventory.Add(eI);
                        this.db.SaveChanges();
                    }
                }

                if (!model.ItsPaid)
                {
                    var curraprovi = this.db.CurrentAcountProvider.Find(model.IdProvider);
                    curraprovi.TotalDebt += model.TotalAmount;
                    this.db.Entry(curraprovi).State = EntityState.Modified;
                    this.db.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        // GET: PDocs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PDoc pDoc = db.PurchaseDocument.Find(id);
            if (pDoc == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCurrentAccountDocumentType = new SelectList(db.CurrentAccountDocumentType, "IdCurrentAccountDocumentType", "TypeName", pDoc.IdCurrentAccountDocumentType);
            ViewBag.IdProvider = new SelectList(db.Provider, "Id", "Name", pDoc.IdProvider);
            ViewBag.PurchaseNumber = new SelectList(db.PurchaseDocument, "Id", "Id", pDoc.PurchaseNumber);
            return View(pDoc);
        }

        // POST: PDocs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PDoc pDoc)
        {
            if (ModelState.IsValid)
            {
                var actualst = this.db.PurchaseDocument.Find(pDoc.Id);

                if (actualst.ItsPaid && !pDoc.ItsPaid)
                {
                    var curraprovi = this.db.CurrentAcountProvider.Find(actualst.IdProvider);
                    curraprovi.TotalDebt += pDoc.TotalAmount;
                    this.db.Entry(curraprovi).State = EntityState.Modified;
                    this.db.SaveChanges();
                }
                else if (!actualst.ItsPaid && pDoc.ItsPaid)
                {
                    var curraprovi = this.db.CurrentAcountProvider.Find(actualst.IdProvider);
                    curraprovi.TotalDebt -= pDoc.TotalAmount;
                    this.db.Entry(curraprovi).State = EntityState.Modified;
                    this.db.SaveChanges();
                }

                actualst.ItsPaid = pDoc.ItsPaid;

                this.db.Entry(actualst).State = EntityState.Modified;
                this.db.SaveChanges();
                return this.RedirectToAction("Index");
            }

            ViewBag.IdCurrentAccountDocumentType = new SelectList(db.CurrentAccountDocumentType, "IdCurrentAccountDocumentType", "TypeName", pDoc.IdCurrentAccountDocumentType);
            ViewBag.IdProvider = new SelectList(db.Provider, "Id", "Name", pDoc.IdProvider);
            ViewBag.PurchaseNumber = new SelectList(db.PurchaseDocument, "Id", "Id", pDoc.PurchaseNumber);
            return View(pDoc);
        }

        // GET: PDocs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PDoc pDoc = db.PurchaseDocument.Find(id);
            if (pDoc == null)
            {
                return HttpNotFound();
            }
            return View(pDoc);
        }

        // POST: PDocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PDoc pDoc = db.PurchaseDocument.Find(id);
            db.PurchaseDocument.Remove(pDoc);
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

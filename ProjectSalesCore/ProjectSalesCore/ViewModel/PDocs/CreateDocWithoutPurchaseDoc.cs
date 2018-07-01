// <copyright file="CreateDocWithoutPurchaseDoc.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ProjectSalesCore.ViewModel.PDocs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using CSales.Database.Models;

    public class CreateDocWithoutPurchaseDoc
    {
        public CreateDocWithoutPurchaseDoc()
        {
            this.OrderDetailsCompras = new List<DPToSale>();
        }

        public int IdProvider { get; set; }

        public IEnumerable<DPToSale> OrderDetailsCompras { get; set; }

        public IEnumerable<Product> Products { get; set; }

        public int IdStorage { get; set; }

        public DateTime CreatedDate { get; set; }

        public Provider Providers { get; set; }

        public int IdCurrentAccountDocumentType { get; set; }

        public bool ItsPaid { get; set; }
    }
}
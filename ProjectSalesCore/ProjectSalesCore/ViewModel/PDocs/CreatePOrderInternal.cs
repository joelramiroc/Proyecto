// <copyright file="CreatePOrderInternal.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ProjectSalesCore.ViewModel.PDocs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using CSales.Database.Models;
    using ProjectSalesCore.ViewModel.PurchaseOrder;

    public class CreatePOrderInternal
    {
        public CreatePOrderInternal()
        {
            this.OrderDetailsCompras = new List<POrderInternalDetail>();
        }

        public int IdProvider { get; set; }

        public CSales.Database.Models.Provider Providers { get; set; }

        public DateTime CreatedDate { get; set; }

        public IEnumerable<PCondition> PConditions { get; set; }

        public IEnumerable<POrderInternalDetail> OrderDetailsCompras { get; set; }

        public IEnumerable<Product> Products { get; set; }

        public int IdStorage { get; set; }

        public int IdCurrentAccountDocumentType { get; set; }

        public bool ItsPaid { get; set; }
    }
}
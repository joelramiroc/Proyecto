// <copyright file="CreatePOrderExternal.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ProjectSalesCore.ViewModel.PurchaseOrder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using CSales.Database.Models;

    public class CreatePOrderExternal
    {
        public CreatePOrderExternal()
        {
            this.OrderDetailsCompras = new List<POrderExternalDetail>();
        }

        public int PurchaseNumber { get; set; }

        public string PlaceOfEntry { get; set; }

        public int IdProvider { get; set; }

        public Provider Providers { get; set; }

        public DateTime CreatedDate { get; set; }

        public int IdPaymentCondition { get; set; }

        public int IdStatusOrder { get; set; }

        public IEnumerable<PCondition> PConditions { get; set; }

        public IEnumerable<POrderExternalDetail> OrderDetailsCompras { get; set; }

        public int IdPCondition { get; set; }

        public IEnumerable<Product> Products { get; set; }

        public int IdStorage { get; set; }
    }
}
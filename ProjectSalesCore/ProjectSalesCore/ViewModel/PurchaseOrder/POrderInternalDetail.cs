// <copyright file="POrderInternalDetail.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ProjectSalesCore.ViewModel.PurchaseOrder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class POrderInternalDetail
    {
        public int Id { get; set; }

        public int IdProduct { get; set; }

        public string Product { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public string Description { get; set; }

        public int Discount { get; set; }
    }
}
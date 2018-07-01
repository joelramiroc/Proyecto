// <copyright file="DetailsOrderDetailViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ProjectSalesCore.ViewModel.PurchaseOrder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class DetailsOrderDetailViewModel
    {
        public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Discount { get; set; }

        public int Quantity { get; set; }

        public decimal TotalAmount { get; set; }

        public bool IsInternalPurchase { get; set; }
    }
}
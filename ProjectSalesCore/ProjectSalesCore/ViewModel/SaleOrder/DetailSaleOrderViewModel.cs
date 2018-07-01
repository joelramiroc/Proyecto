// <copyright file="DetailSaleOrderViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ProjectSalesCore.ViewModel.SaleOrder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class DetailSaleOrderViewModel
    {
        
        public int Id { get; set; }

        public int IdProduct { get; set; }

        public string Product { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Discount { get; set; }

        public string Description { get; set; }
    }
}
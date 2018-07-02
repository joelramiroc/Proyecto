// <copyright file="SaleBDIndexViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ProjectSalesCore.ViewModel.SaleByDispatch
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class SaleBDIndexViewModel
    {
        public DateTime CreatedDate { get; set; }

        public string EmployeeName { get; set; }

        public string ClientName { get; set; }

        public decimal TotalAmont { get; set; }

        public int IdSaleOrder { get; set; }

        public int Id { get; set; }
    }
}
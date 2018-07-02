// <copyright file="DetailSaleBDispatchViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ProjectSalesCore.ViewModel.SaleOrder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using ProjectSalesCore.DataBase.Models;

    public class DetailSaleBDispatchViewModel
    {
        public DetailSaleBDispatchViewModel()
        {
            this.DetailVentas = new List<OrderDetailsVentas>();
        }

        public int Id { get; set; }

        public IEnumerable<OrderDetailsVentas> DetailVentas { get; set; }

        public string EmployeeName { get; set; }

        public string ClientName { get; set; }

        public DateTime CreatedDate { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
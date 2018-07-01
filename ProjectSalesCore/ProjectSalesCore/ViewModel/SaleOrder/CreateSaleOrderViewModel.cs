// <copyright file="CreateSaleOrderViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ProjectSalesCore.ViewModel.SaleOrder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using ProjectSalesCore.DataBase.Models;
    using ProjectSalesCore.ViewModel.PurchaseOrder;
    using CSales.Database.Models;

    public class CreateSaleOrderViewModel
    {
        public CreateSaleOrderViewModel()
        {
            this.OrderDetailsCompras = new List<POrderExternalDetail>();
        }

        public int IdEmployee { get; set; }

        public Employee Employee { get; set; }

        public int IdClient { get; set; }

        public Client Client { get; set; }

        public DateTime CreatedDate { get; set; }

        public int IdPaymentCondition { get; set; }

        public IEnumerable<POrderExternalDetail> OrderDetailsCompras { get; set; }

        public int IdPCondition { get; set; }

        public IEnumerable<ExternalInventory> Products { get; set; }

        public int IdStorage { get; set; }
    }
}
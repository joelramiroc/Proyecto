// <copyright file="AddProcuctsToAlmacenController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ProjectSalesCore.ViewModel.PurchaseOrder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class AddProcuctsToAlmacenViewModel
    {
        public string ProviderName { get; set; }

        public int PurchaseNumber { get; set; }

        public int IdStorage { get; set; }
    }
}
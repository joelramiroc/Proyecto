// <copyright file="CreateSBDispatchViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ProjectSalesCore.ViewModel.SaleOrder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class CreateSBDispatchViewModel
    {
        public int idSaleOrder { get; set; }

        public int IdEmployee { get; set; }

        public int IdCurrentAccountDocumentType { get; set; }
    }
}
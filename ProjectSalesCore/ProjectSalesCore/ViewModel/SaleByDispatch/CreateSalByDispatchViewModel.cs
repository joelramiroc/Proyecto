// <copyright file="CreateSalByDispatchViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ProjectSalesCore.ViewModel.SaleByDispatch
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class CreateSalByDispatchViewModel
    {
        public int IdSaleOrder { get; set; }

        public int IdEmployee { get; set; }

        public int IdCurrentAccountDocumentType { get; set; }
    }
}
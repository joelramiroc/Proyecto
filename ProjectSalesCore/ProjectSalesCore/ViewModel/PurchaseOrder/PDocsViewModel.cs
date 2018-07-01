// <copyright file="PDocsViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ProjectSalesCore.ViewModel.PurchaseOrder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class PDocsViewModel
    {
        public int idPDoc { get; set; }

        public int IdCurrentAccountDocumentType { get; set; }

        public bool ItsPaid { get; set; }
    }
}
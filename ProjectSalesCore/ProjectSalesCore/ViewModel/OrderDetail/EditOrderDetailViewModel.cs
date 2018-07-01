namespace ProjectSalesCore.ViewModel.OrderDetail
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;
    using CSales.Database.Models;
    using ProjectSalesCore.DataBase.Models;

    public class EditOrderDetailViewModel
    {
        public long IdExternalProduct { get; set; }

        public EProduct ExternalProduct { get; set; }

        public long IdSaleOrder { get; set; }

        public SaleOrder SaleOrder { get; set; }

        public int Quantity { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal UnitPrice { get; set; }

        public int DiscountRate { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal Total { get; set; }
    }
}
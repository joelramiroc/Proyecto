using CSales.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectSalesCore.ViewModel.PurchaseOrder
{
    public class CreatePOrderInternal
    {
        public CreatePOrderInternal()
        {
            this.OrderDetailsCompras = new List<POrderInternalDetail>();
        }

        public int PurchaseNumber { get; set; }

        public string PlaceOfEntry { get; set; }

        public int IdProvider { get; set; }

        public CSales.Database.Models.Provider Providers { get; set; }

        public DateTime CreatedDate { get; set; }

        public int IdPaymentCondition { get; set; }

        public int IdStatusOrder { get; set; }

        public IEnumerable<PCondition> PConditions { get; set; }

        public IEnumerable<POrderInternalDetail> OrderDetailsCompras { get; set; }

        public int IdPCondition { get; set; }

        public IEnumerable<Product> Products { get; set; }

        public int IdStorage { get; set; }
    }
}
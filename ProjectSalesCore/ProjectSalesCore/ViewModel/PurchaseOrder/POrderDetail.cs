using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectSalesCore.ViewModel.PurchaseOrder
{
    public class POrderDetail
    {
        public IEnumerable<DetailsOrderDetailViewModel> DetailsOrderDetailViewModels { get; set; }

        public int PurchaseNumber { get; set; }

        public string ProviderName { get; set; }

        public string PaymentCondition { get; set; }

        public DateTime CreatedDate { get; set; }

        public string PlaceOfEntry { get; set; }

        public decimal TotalAmount { get; set; }

        public string StatusOrder { get; set; }

        public bool IsInternalPurchase { get; set; }
    }
}
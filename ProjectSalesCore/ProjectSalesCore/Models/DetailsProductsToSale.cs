// <copyright file="DetailsPurchaseOrder.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CSales.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CSales.Database.Models;

    [Table("DPTOSALE")]

    public class DetailsProductsToSale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID")]
        public int Id { get; set; }

        [ForeignKey(nameof(Product))]
        [Column("IDP")]
        public int IdProduct { get; set; }

        [Column("PRODUCT")]
        public virtual Product Product { get; set; }

        [Column("QUANTITY")]
        public int Quantity { get; set; }

        [Column("UNITPRICE")]
        public decimal UnitPrice { get; set; }

        [Column("DISCOUNT")]
        public decimal? Discount { get; set; }

        [Column("TOTALAMOUNT")]
        public decimal TotalAmount { get; set; }

        [ForeignKey(nameof(PaymentCondition))]
        [Column("IDPC")]
        public int IdPaymentCondition { get; set; }

        [Column("PAYMENTCONDITION")]
        public virtual PCondition PaymentCondition { get; set; }

        [ForeignKey(nameof(PurchaseOrder))]
        [Column("PO")]
        public int PurchaseNumber { get; set; }

        [Column("PURCHASEORDER")]
        public virtual POrder PurchaseOrder { get; set; }
    }
}

// <copyright file="OrderDetail.cs" company="PlaceholderCompany">
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

    [Table("ODETAIL")]

    public class OrderDetail
    {
        [Key]
        [ForeignKey(nameof(ExternalProduct))]
        [Column("IDXP",Order =0)]
        public int IdExternalProduct { get; set; }

        [Column("EXTERNALPRODUCT")]
        public EProduct ExternalProduct { get; set; }

        [Key]
        [ForeignKey(nameof(SaleOrder))]
        [Column("IDSORDER",Order =1)]
        public int IdSaleOrder { get; set; }

        [Column("SALEORDER")]
        public SaleOrder SaleOrder { get; set; }

        [Column("QUANTITY")]
        public int Quantity { get; set; }

        [Column("UNITPRICE")]
        public decimal UnitPrice { get; set; }

        [Column("DISCOUNTRATE")]
        public int DiscountRate { get; set; }

        [Column("TOTAL")]
        public decimal Total { get; set; }
    }
}

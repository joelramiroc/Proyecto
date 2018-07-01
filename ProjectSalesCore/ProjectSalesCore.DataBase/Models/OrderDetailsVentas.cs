// <copyright file="OrderDetailsVentas.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ProjectSalesCore.DataBase.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using CSales.Database.Models;

    [Table("ODVNTS")]

    public class OrderDetailsVentas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int Id { get; set; }

        [ForeignKey(nameof(EProdct))]
        [Column("IDXP")]
        public int IdExternalProduct { get; set; }

        [Column("EPRDCT")]
        public EProduct EProdct { get; set; }

        [ForeignKey(nameof(SaleOrder))]
        [Column("IDSORDER")]
        public int IdSaleOrder { get; set; }

        [Column("SALEORDER")]
        public SaleOrder SaleOrder { get; set; }

        [Column("QUANTITY")]
        public int Quantity { get; set; }

        [Column("UNITPRICE")]
        public decimal UnitPrice { get; set; }

        [Column("DISCOUNTRATE")]
        public decimal DiscountRate { get; set; }

        [Column("TOTAL")]
        public decimal Total { get; set; }
    }
}
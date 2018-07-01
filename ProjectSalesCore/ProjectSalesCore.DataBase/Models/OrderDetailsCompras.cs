// <copyright file="OrderDetailsCompras.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ProjectSalesCore.DataBase.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CSales.Database.Models;

    [Table("ODCO")]
    public class OrderDetailsCompras
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        [ForeignKey(nameof(POrder))]
        [Column("PO")]
        public int PurchaseNumber { get; set; }

        [Column("PORDER")]
        public virtual POrder POrder { get; set; }

        [Column("DESCRIPTION")]
        public string Description { get; set; }
    }
}

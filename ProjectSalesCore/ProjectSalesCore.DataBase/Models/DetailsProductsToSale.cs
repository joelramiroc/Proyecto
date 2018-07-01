// <copyright file="DetailsPurchaseOrder.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CSales.Database.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Table("DPTOSALE")]

    public class DPToSale
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
        public decimal Discount { get; set; }

        [Column("TOTALAMOUNT")]
        public decimal TotalAmount { get; set; }

        [Column("DESCRIPTION")]
        public string Description { get; set; }

        [ForeignKey(nameof(PurchaseDocument))]
        [Column("IDPDOC")]
        public int IdPDoc { get; set; }

        [Column("PDOC")]
        public virtual PDoc PurchaseDocument { get; set; }
    }
}

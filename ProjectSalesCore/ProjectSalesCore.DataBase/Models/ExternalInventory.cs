// <copyright file="ExternalInventory.cs" company="PlaceholderCompany">
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

    [Table("EXTINV")]

    public class ExternalInventory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int Id { get; set; }

        [ForeignKey(nameof(EPrdct))]
        [Column("IDEP")]
        public int IdEProduct { get; set; }

        [Column("EPRDCT")]
        public virtual EProduct EPrdct { get; set; }

        [ForeignKey(nameof(Storage))]
        [Column("IDSTORAGE")]
        public int IdStorage { get; set; }

        [Column("STORAGE")]
        public virtual Storage Storage { get; set; }

        [Column("PRODUCTDESCRIPTION")]
        public string ProductDescription { get; set; }

        [Column("QUANTITY")]
        public int Quantity { get; set; }

        [Column("UNITPRICE")]
        public decimal UnitPrice { get; set; }

        [Column("DISCOUNTRATE")]
        public int DiscountRate { get; set; }

        [Column("MINIMUMSTOCK")]
        public int MinimumStock { get; set; }

        [Column("MAXIMUMSTOCK")]
        public int MaximumStock { get; set; }
    }
}

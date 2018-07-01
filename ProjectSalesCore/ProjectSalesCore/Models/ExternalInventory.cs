// <copyright file="ExternalInventory.cs" company="PlaceholderCompany">
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

    [Table("EXTINV")]

    public class ExternalInventory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID")]
        public int IdExternalInventory { get; set; }

        [ForeignKey(nameof(ExternalProduct))]
        [Column("IDEP")]
        public int IdExternalProduct { get; set; }

        [Column("EXTERNALPRODUCT")]
        public virtual EProduct ExternalProduct { get; set; }

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

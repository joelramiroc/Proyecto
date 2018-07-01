// <copyright file="InternalInventory.cs" company="PlaceholderCompany">
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

    [Table("IINV")]

    public class InternalInventory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID")]
        public int IdInternalInventory { get; set; }

        [ForeignKey(nameof(Storage))]
        [Column("IDSTORAGE")]
        public int IdStorage { get; set; }

        [Column("SOTRAGE")]
        public virtual Storage Storage { get; set; }

        [ForeignKey(nameof(InternalProduct))]
        [Column("IDIP")]
        public int IdInternalProduct { get; set; }

        [Column("INTERNALPRODUCT")]
        public virtual InternalProduct InternalProduct { get; set; }

        [Column("PRODUCTDESCRIPTION")]
        public string ProductDescription { get; set; }

        [Column("QUANTITY")]
        public int Quantity { get; set; }
    }
}

// <copyright file="InternalInventory.cs" company="PlaceholderCompany">
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

    [Table("IINV")]

    public class InternalInventory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int IdInternalInventory { get; set; }

        [ForeignKey(nameof(Storage))]
        [Column("IDST")]
        public int IdStorage { get; set; }

        [Column("ST")]
        public virtual Storage Storage { get; set; }

        [ForeignKey(nameof(IPrdct))]
        [Column("IDIP")]
        public int IdIProduct { get; set; }

        [Column("IPRDCT")]
        public virtual IProduct IPrdct { get; set; }

        [Column("PRODUCTDESCRIPTION")]
        public string ProductDescription { get; set; }

        [Column("QUANTITY")]
        public int Quantity { get; set; }
    }
}

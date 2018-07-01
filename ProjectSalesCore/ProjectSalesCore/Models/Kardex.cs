// <copyright file="Kardex.cs" company="PlaceholderCompany">
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

    [Table("KARDEX")]

    public class Kardex
    {
        [Key]
        public int IdKardex { get; set; }

        [ForeignKey(nameof(MovementType))]
        [Column("IDMOVEMENTTYPE")]
        public int IdMovementType { get; set; }

        [Column("MOVEMENTTYPE")]
        public virtual MovementType MovementType { get; set; }

        [ForeignKey(nameof(Product))]
        [Column("IDPRODUCT")]
        public int IdProduct { get; set; }

        [Column("PRODUCT")]
        public virtual Product Product { get; set; }

        [Column("QUANTITY")]
        public int Quantity { get; set; }

        [Column("UNITPRICE")]
        public decimal UnitPrice { get; set; }

        [Column("DISCOUNTRATE")]
        public int DiscountRate { get; set; }

        [Column("TOTAL")]
        public decimal Total { get; set; }

        [ForeignKey(nameof(Storage))]
        [Column("IDSTORAGE")]
        public int IdStorage { get; set; }

        [Column("STORAGE")]
        public virtual Storage Storage { get; set; }

        [Column("MOVEMENTDATE")]
        public DateTime MovementDate { get; set; }

        [Column("PREVIOUSBALANCE")]
        public decimal PreviousBalance { get; set; }

        [Column("NEWBALANCE")]
        public decimal NewBalance { get; set; }

        [Column("PREVIOUSSTOCK")]
        public int PreviousStock { get; set; }

        [Column("NEWSTOCK")]
        public int NewStock { get; set; }
    }
}

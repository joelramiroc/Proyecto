// <copyright file="Product.cs" company="PlaceholderCompany">
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

    [Table("PDTO")]

    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int IdProduct { get; set; }

        [Column("PRODUCTNAME")]
        public string ProductName { get; set; }


        [ForeignKey(nameof(UnitOfMeasurement))]
        [Column("IDM")]
        public int IdUnitOfMeasurement { get; set; }

        [Column("UNITOFMEASUREMENT")]
        public virtual UOfMeasur UnitOfMeasurement { get; set; }

        [ForeignKey(nameof(ProductType))]
        [Column("IDPT")]
        public int IdProductType { get; set; }

        [Column("PRODUCTTYPE")]
        public virtual ProductType ProductType { get; set; }

        [ForeignKey(nameof(ProductLine))]
        [Column("IDPL")]
        public int IdProductLine { get; set; }

        [Column("PRODUCTLINE")]
        public virtual ProductLine ProductLine { get; set; }
    }
}

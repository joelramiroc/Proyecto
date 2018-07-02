// <copyright file="CounterSale.cs" company="PlaceholderCompany">
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

    [Table("CSALE")]

    public class CounterSale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int Id { get; set; }

        [Column("CD")]
        public DateTime CreatedDate { get; set; }

        [Column("BILLS")]
        public ICollection<Bill> Bills { get; set; }

        [Column("SALES")]
        public ICollection<Sale> Sales { get; set; }

        [ForeignKey(nameof(SaleOrder))]
        [Column("IDSO")]
        public int IdSaleOrder { get; set; }

        [Column("SO")]
        public virtual SaleOrder SaleOrder { get; set; }

        [ForeignKey(nameof(Employee))]
        [Column("IDEMP")]
        public int IdEmployee { get; set; }

        [Column("E")]
        public virtual Employee Employee { get; set; }

        [Column("ITSPAID")]
        public bool itsPaid { get; set; }
    }
}

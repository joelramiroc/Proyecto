// <copyright file="EmailEmployee.cs" company="PlaceholderCompany">
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

    [Table("EMAILE")]
    public class EmailEmployee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IDEMAIL")]
        public int IdEmail { get; set; }

        [Column("EMAILL")]
        public string Emaill { get; set; }

        [ForeignKey(nameof(Employee))]
        [Column("IDEMP")]
        public int IdEMP { get; set; }

        [Column("EMP")]
        public virtual Employee Employee { get; set; }
    }
}

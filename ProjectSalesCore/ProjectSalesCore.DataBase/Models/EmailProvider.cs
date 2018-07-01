// <copyright file="EmailProvider.cs" company="PlaceholderCompany">
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

    [Table("EMAILP")]
    public class EmailProvider
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IDEMAIL")]
        public int IdEmail { get; set; }

        [Column("EMAILL")]
        public string Emaill { get; set; }

        [ForeignKey(nameof(Provider))]
        [Column("IDPRV")]
        public int IdPRV { get; set; }

        [Column("PRV")]
        public virtual Provider Provider { get; set; }
    }
}

// <copyright file="AddressProvider.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ProjectSalesCore.DataBase.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using CSales.Database.Models;

    [Table("APRV")]
    public class AddressProvider
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int Id { get; set; }

        [Column("ADDRESSNAME")]
        public string AddressName { get; set; }

        [Column("DESCRIPTION")]
        public string Description { get; set; }

        [ForeignKey(nameof(Provider))]
        [Column("IDPRV")]
        public int IdPRV { get; set; }

        [Column("PRV")]
        public virtual Provider Provider { get; set; }
    }
}

﻿// <copyright file="Address.cs" company="PlaceholderCompany">
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

    [Table("ADDRESS")]

    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID")]
        public int Id { get; set; }

        [Column("ADDRESSNAME")]
        public string AddressName { get; set; }

        [Column("DESCRIPTION")]
        public string Description { get; set; }
    }
}
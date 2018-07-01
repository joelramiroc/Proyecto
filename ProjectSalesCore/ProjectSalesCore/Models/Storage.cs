// <copyright file="Storage.cs" company="PlaceholderCompany">
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

    [Table("STOR")]

    public class Storage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID")]
        public int IdStorage { get; set; }

        [Column("STORAGENAME")]
        public string StorageName { get; set; }

        [ForeignKey(nameof(Address))]
        [Column("IDADDRESS")]
        public int IdAddress { get; set; }

        [Column("ADDRESSS")]
        public virtual Address Address { get; set; }

        [Column("CLS")]
        public ICollection<Telephone> Telephones { get; set; }

        [Column("CREATEDDATE")]
        public DateTime CreatedDate { get; set; }

    }
}

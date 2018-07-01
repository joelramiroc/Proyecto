// <copyright file="Client.cs" company="PlaceholderCompany">
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

    [Table("CLIENT")]

    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID")]
        public int Id { get; set; }

        [Column("NAME")]
        public string Name { get; set; }

        [Column("ADDRESSES")]
        public ICollection<Address> Addresses { get; set; }

        [Column("CITIES")]
        public ICollection<CityDistrict> CitiesDistricts { get; set; }

        [Column("TELEPHONES")]
        public ICollection<Telephone> Telephones { get; set; }

        [Column("FAX")]
        public ICollection<Fax> Faxs { get; set; }

        [Column("EMAILS")]
        public ICollection<Email> Emails { get; set; }

        [ForeignKey(nameof(RUC))]
        [Column("IDRUC")]
        public int IdRUC { get; set; }

        [Column("RUC")]
        public virtual RUC RUC { get; set; }

        [ForeignKey(nameof(Employee))]
        [Column("IDEMPLOYEE")]
        public int IdEmployee { get; set; }

        [Column("EMPLOYEE")]
        public virtual Employee Employee { get; set; }
    }
}

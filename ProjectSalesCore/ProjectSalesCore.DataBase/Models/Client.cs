// <copyright file="Client.cs" company="PlaceholderCompany">
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
    using ProjectSalesCore.DataBase.Models;

    [Table("CLIENT")]

    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int Id { get; set; }

        [Column("NAME")]
        public string Name { get; set; }

        [Column("ADDRESSES")]
        public ICollection<AddressClient> Addresses { get; set; }

        [Column("CITIES")]
        public ICollection<CityClient> CitiesDistricts { get; set; }

        [Column("TELEPHONES")]
        public ICollection<TelephoneClient> Telephones { get; set; }

        [Column("FAX")]
        public ICollection<Fax> Faxs { get; set; }

        [Column("EMAILS")]
        public ICollection<EmailClient> Emails { get; set; }

        [ForeignKey(nameof(RUC))]
        [Column("IDRUC")]
        public int IdRUC { get; set; }

        [Column("RUC")]
        public virtual RUC RUC { get; set; }

        [ForeignKey(nameof(Employee))]
        [Column("IDEMP")]
        public int IdEmployee { get; set; }

        [Column("EMPLOYEE")]
        public virtual Employee Employee { get; set; }
    }
}

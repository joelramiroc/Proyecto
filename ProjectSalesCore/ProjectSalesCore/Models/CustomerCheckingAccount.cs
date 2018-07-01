// <copyright file="CustomerCheckingAccount.cs" company="PlaceholderCompany">
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

    [Table("CCACOUNT")]

    public class CustomerCheckingAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID")]
        public int IdCustomerCheckingAccount { get; set; }

        [ForeignKey(nameof(Client))]
        [Column("IDC")]
        public int IdClient { get; set; }

        [Column("CLIENT")]
        public virtual Client Client { get; set; }

        [Column("TOTALDEBT")]
        public decimal TotalDebt { get; set; }

        [Column("CREATEDDATE")]
        public DateTime CreatedDate { get; set; }
    }
}

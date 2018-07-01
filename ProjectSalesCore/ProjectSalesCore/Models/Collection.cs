// <copyright file="Collections.cs" company="PlaceholderCompany">
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

    [Table("COLLECTION")]

    public class Collection
    {
        [Key]
        [ForeignKey(nameof(Client))]
        [Column("IDCLIENT",Order =0)]
        public int IdClient { get; set; }

        [Column("CLIENT")]
        public virtual Client Client { get; set; }

        [ForeignKey(nameof(PaymentMethod))]
        [Column("IDPAYm")]
        public int IdPayM { get; set; }

        [Column("PAYMENTMETHOD")]
        public virtual PaymentMethod PaymentMethod { get; set; }

        [ForeignKey(nameof(Bank))]
        [Column("IDBANK")]
        public int IdBank { get; set; }

        [Column("BANK")]
        public virtual Bank Bank { get; set; }

        [ForeignKey(nameof(TypeOfSaleDocument))]
        [Column("IDTDFS")]
        public int IdTypeDocumentForSale { get; set; }

        [Column("TYPEOFSALEDOCUMENT")]
        public virtual TOSDoc TypeOfSaleDocument { get; set; }

        [Column("IDDOCUMENT")]
        public int IdDocument { get; set; }

        [Key]
        [ForeignKey(nameof(Check))]
        [Column("IDCHECK",Order =1)]
        public int IdCheck { get; set; }

        [Column("CHECK")]
        public virtual Check Check { get; set; }
    }
}

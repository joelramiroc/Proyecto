// <copyright file="Collections.cs" company="PlaceholderCompany">
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
        [Column("IDPAYM")]
        public int IdPayM { get; set; }

        [Column("PAYMENTMETHOD")]
        public virtual PaymentMethod PaymentMethod { get; set; }

        [ForeignKey(nameof(Bank))]
        [Column("IDBANK")]
        public int IdBank { get; set; }

        [Column("BANK")]
        public virtual Bank Bank { get; set; }

        [ForeignKey(nameof(TOSDoc))]
        [Column("IDTDFS")]
        public int IdTypeDocumentForSale { get; set; }

        [Column("TYPESALEDOC")]
        public virtual TOSDoc TOSDoc { get; set; }

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

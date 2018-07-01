// <copyright file="CreditNote.cs" company="PlaceholderCompany">
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

    [Table("CNOTE")]

    public class CreditNote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID")]
        public int IdCreditNote { get; set; }

        [ForeignKey(nameof(CreditNoteType))]
        [Column("IdCNType")]
        public int IdCreditNoteType { get; set; }

        [Column("CRNTYPE")]
        public virtual CreditNoteType CreditNoteType { get; set; }

        [ForeignKey(nameof(Client))]
        [Column("IDCLIENT")]
        public int IdClient { get; set; }

        [Column("CLIENT")]
        public virtual Client Client { get; set; }

        [ForeignKey(nameof(Employee))]
        [Column("IDEMPLOYEE")]
        public int IdEmployee { get; set; }

        [Column("EMPLOYEE")]
        public virtual Employee Employee { get; set; }

        [Column("TOTAL")]
        public decimal Total { get; set; }

        [ForeignKey(nameof(TypeOfSaleDocument))]
        [Column("IdTDFSale")]
        public int IdTypeDocumentForSale { get; set; }

        [Column("TYPEOFSALEDOCUMENT")]
        public virtual TOSDoc TypeOfSaleDocument { get; set; }
    }
}

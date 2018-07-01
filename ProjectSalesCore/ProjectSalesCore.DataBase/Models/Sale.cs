// <copyright file="Sale.cs" company="PlaceholderCompany">
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

    [Table("SALE")]

    public class Sale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IDSALE")]
        public int IdSale { get; set; }

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

        [ForeignKey(nameof(OutputNote))]
        [Column("IDNOTEOUTPUT")]
        public int IdNoteOutput { get; set; }

        [Column("OUTPUTNOTE")]
        public OutputNote OutputNote { get; set; }

        [Column("CREATEDDATE")]
        public DateTime CreatedDate { get; set; }

        [ForeignKey(nameof(SaByDisp))]
        [Column("SBD")]
        public int? IdSaleByDispatch { get; set; }

        [Column("SaByDisp")]
        public virtual SaByDisp SaByDisp { get; set; }

        [ForeignKey(nameof(CounterSale))]
        [Column("ICS")]
        public int? IdCounterSale { get; set; }

        [Column("CS")]
        public virtual CounterSale CounterSale { get; set; }

        [ForeignKey(nameof(PDoc))]
        [Column("IPD")]
        public int? idPdoc { get; set; }

        [Column("PD")]
        public virtual PDoc PDoc { get; set; }
    }
}

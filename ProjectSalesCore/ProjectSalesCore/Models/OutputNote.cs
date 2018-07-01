// <copyright file="OutputNote.cs" company="PlaceholderCompany">
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

    [Table("ONOTE")]

    public class OutputNote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("IDONOTE")]
        public int IdOutputNote { get; set; }

        [ForeignKey(nameof(SaleOrder))]
        [Column("IDSALEORDER")]
        public int IdSaleOrder { get; set; }

        [Column("SALEORDER")]
        public virtual SaleOrder SaleOrder { get; set; }

        [ForeignKey(nameof(OutputNoteStatus))]
        [Column("IDONSTATUS")]
        public int IdOutputNoteStatus { get; set; }

        [Column("OUTPUTNOTESTATUS")]
        public virtual StatusNote OutputNoteStatus { get; set; }

        [ForeignKey(nameof(ReasonNote))]
        [Column("IDRNOTE")]
        public int IdReasonNote { get; set; }

        [Column("REASONNOTE")]
        public virtual ReasonNote ReasonNote { get; set; }

        [ForeignKey(nameof(Bill))]
        [Column("IDBILL")]
        public int IdBill { get; set; }

        [Column("BILL")]
        public virtual Bill Bill { get; set; }
    }
}

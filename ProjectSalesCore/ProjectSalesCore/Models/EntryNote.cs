// <copyright file="EntryNote.cs" company="PlaceholderCompany">
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
    using CSales.Database.Models;

    [Table("ENOTE")]

    public class EntryNote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("ID")]
        public int IdEntryNote { get; set; }

        [ForeignKey(nameof(PurchaseOrder))]
        [Column("NPO")]
        public int NumberPurchaseOrder { get; set; }

        [Column("PURCHASEORDER")]
        public virtual POrder PurchaseOrder { get; set; }

        [ForeignKey(nameof(EntryNoteStatus))]
        [Column("IDENST")]
        public int IdEntryNoteStatus { get; set; }

        [Column("ENTRYNOTESTATUS")]
        public virtual StatusNote EntryNoteStatus { get; set; }

        [ForeignKey(nameof(ReasonNote))]
        [Column("IDRNOTE")]
        public int IdReasonNote { get; set; }

        [Column("REASONNOTE")]
        public virtual ReasonNote ReasonNote { get; set; }

        [ForeignKey(nameof(PDoc))]
        [Column("IDPDOC")]
        public int IdPurchaseDocument { get; set; }

        [Column("PDOC")]
        public virtual PDoc PDoc { get; set; }
    }
}

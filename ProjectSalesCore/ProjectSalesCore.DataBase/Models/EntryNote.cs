// <copyright file="EntryNote.cs" company="PlaceholderCompany">
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

    [Table("ENOTE")]

    public class EntryNote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int IdEntryNote { get; set; }

        [ForeignKey(nameof(POrder))]
        [Column("NPO")]
        public int NumberPurchaseOrder { get; set; }

        [Column("PORDER")]
        public virtual POrder POrder { get; set; }

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
        public int IdPDoc { get; set; }

        [Column("PDOC")]
        public virtual PDoc PDoc { get; set; }
    }
}

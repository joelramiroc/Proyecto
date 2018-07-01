// <copyright file="DebitNote.cs" company="PlaceholderCompany">
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

    [Table("DNOTE")]

    public class DebitNote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int IdDebitNote { get; set; }

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

        [ForeignKey(nameof(TOSDoc))]
        [Column("IDDOCFORSALE")]
        public int IdTOSDoc { get; set; }

        [Column("IDTDFORSALE")]
        public virtual TOSDoc TOSDoc { get; set; }

        [Column("IDDOCUMENT")]
        public int IdDocument { get; set; }

        [Column("TOTAL")]
        public decimal Total { get; set; }
    }
}

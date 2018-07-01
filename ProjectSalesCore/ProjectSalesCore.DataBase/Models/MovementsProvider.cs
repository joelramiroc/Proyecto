// <copyright file="MovimentsProvider.cs" company="PlaceholderCompany">
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

    [Table("MPROVIDER")]

    public class MovementsProvider
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IDMPROVIDER")]
        public int IdMovementsProvider { get; set; }

        [ForeignKey(nameof(DTProvdr))]
        [Column("IDDTPE")]
        public int IdDocumentType { get; set; }

        [Column("DTYPEPROV")]
        public virtual TOPDoc DTProvdr { get; set; }

        [Column("DOCUMENTID")]
        public int DocumentId { get; set; }

        [Column("INGRESOS")]
        public decimal Ingresos { get; set; }

        [Column("EGRESOS")]
        public decimal Egresos { get; set; }

        [Column("CREATEDDATE")]
        public DateTime CreatedDate { get; set; }
    }
}

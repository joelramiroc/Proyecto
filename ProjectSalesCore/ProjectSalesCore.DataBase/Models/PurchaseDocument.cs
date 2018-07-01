// <copyright file="PurchaseDocument.cs" company="PlaceholderCompany">
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
    using ProjectSalesCore.DataBase.Models;

    [Table("PDOC")]

    public class PDoc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int Id { get; set; }

        [ForeignKey(nameof(Provider))]
        [Column("PROVIDER")]
        public int IdProvider { get; set; }

        [Column("PROVIDER")]
        public virtual Provider Provider { get; set; }

        [ForeignKey(nameof(CurrentAccountDocumentType))]
        [Column("IDDT")]
        public int IdCurrentAccountDocumentType { get; set; }

        [Column("CURRENTACCOUNTDOCUMENTTYPE")]
        public virtual CurrentAccountDocumentType CurrentAccountDocumentType { get; set; }

        [Column("CREATEDDATE")]
        public DateTime CreatedDate { get; set; }

        [Column("DP")]
        public ICollection<DPToSale> DPTSales { get; set; }

        [Column("TOTALAMOUNT")]
        public decimal TotalAmount { get; set; }

        [ForeignKey(nameof(PurchaseDocument))]
        [Column("PN")]
        public int? PurchaseNumber { get; set; }

        [Column("PDOC")]
        public POrder PurchaseDocument { get; set; }

        [Column("ISWITHORDER")]
        public bool IsWithOrder { get; set; }

        [Column("ITSPAID")]
        public bool ItsPaid { get; set; }
    }
}

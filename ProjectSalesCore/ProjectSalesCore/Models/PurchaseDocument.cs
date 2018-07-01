// <copyright file="PurchaseDocuments.cs" company="PlaceholderCompany">
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

    [Table("PDOC")]

    public class PDoc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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

        [ForeignKey(nameof(PurchaseOrder))]
        [Column("NPORDER")]
        public int NumberPurchaseOrder { get; set; }

        [Column("PURCHASEORDER")]
        public virtual POrder PurchaseOrder { get; set; }

        [Column("CREATEDDATE")]
        public DateTime CreatedDate { get; set; }

        [Column("DP")]
        public ICollection<DetailsProductsToSale> DPTSales { get; set; }

        [Column("TOTALAMOUNT")]
        public decimal TotalAmount { get; set; }
    }
}

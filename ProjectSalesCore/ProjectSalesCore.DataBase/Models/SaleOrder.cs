// <copyright file="SaleOrder.cs" company="PlaceholderCompany">
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

    [Table("SOR")]

    public class SaleOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID")]
        public int IdSaleOrder { get; set; }

        [Column("CREATEDDATE")]
        public DateTime CreatedDate { get; set; }

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

        [ForeignKey(nameof(PaymentCondition))]
        [Column("IDPCONDITION")]
        public int IdPaymentCondition { get; set; }

        [Column("PAYMENTCONDITION")]
        public virtual PCondition PaymentCondition { get; set; }

        [Column("ODETAILS")]
        public ICollection<OrderDetailsVentas> OrderDetails { get; set; }

        [ForeignKey(nameof(Storage))]
        [Column("ISTOR")]
        public int IdStorage { get; set; }

        [Column("STOR")]
        public Storage Storage { get; set; }
    }
}
namespace ProjectSalesCore.ViewModel.Account
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;
    using CSales.Database.Models;
    using ProjectSalesCore.DataBase.Models;

    public class CreateCurrentAccountProviderViewModel
    {
        public long IdCurrentAccountProvider { get; set; }

        public long IdProvider { get; set; }

        public virtual Provider Provider { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal TotalDebt { get; set; }
    }
}
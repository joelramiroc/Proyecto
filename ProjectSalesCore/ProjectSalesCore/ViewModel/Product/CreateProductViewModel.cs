namespace ProjectSalesCore.ViewModel.Product
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;
    using CSales.Database.Models;
    using ProjectSalesCore.DataBase.Models;
    using CSales.Models;

    public class CreateProductViewModel
    {
        public long IdProduct { get; set; }

        public string ProductName { get; set; }
    }
}
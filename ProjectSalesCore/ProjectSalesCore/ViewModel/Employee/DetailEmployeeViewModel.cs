// <copyright file="DetailEmployeeViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ProjectSalesCore.ViewModel.Employee
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using ProjectSalesCore.DataBase.Models;

    public class DetailEmployeeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<TelephoneEmployee> Telephones { get; set; }

        public IEnumerable<AddressEmployee> Addresses { get; set; }

        public DateTime HireDate { get; set; }

        public decimal Salary { get; set; }
    }
}
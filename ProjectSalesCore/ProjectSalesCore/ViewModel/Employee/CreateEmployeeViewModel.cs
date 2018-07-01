// <copyright file="CreateEmployeeViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ProjectSalesCore.ViewModel.Employee
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using ProjectSalesCore.DataBase.Models;

    public class CreateEmployeeViewModel
    {

        public string Name { get; set; }

        public IEnumerable<string> Telephones { get; set; }

        public IEnumerable<string> Addresses { get; set; }

        public DateTime HireDate { get; set; }

        public decimal Salary { get; set; }

    }
}
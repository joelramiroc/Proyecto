// <copyright file="CreateClientViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ProjectSalesCore.ViewModel.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using CSales.Database.Models;
    using ProjectSalesCore.DataBase.Models;

    public class CreateClientViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<string> Addresses { get; set; }

        public IEnumerable<string> CitiesDistricts { get; set; }

        public IEnumerable<string> Telephones { get; set; }

        public IEnumerable<string> Faxs { get; set; }

        public IEnumerable<string> Emails { get; set; }

        public int IdRUC { get; set; }

        public int IdEmployee { get; set; }
    }
}
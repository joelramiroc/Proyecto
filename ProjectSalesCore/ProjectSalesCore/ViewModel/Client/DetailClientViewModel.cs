// <copyright file="DetailClientViewModel.cs" company="PlaceholderCompany">
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

    public class DetailClientViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<AddressClient> Addresses { get; set; }

        public IEnumerable<CityClient> CitiesDistricts { get; set; }

        public IEnumerable<TelephoneClient> Telephones { get; set; }

        public IEnumerable<string> Faxs { get; set; }

        public IEnumerable<EmailClient> Emails { get; set; }

        public int IdRUC { get; set; }

        public RUC RUC { get; set; }

        public Employee Employee { get; set; }

        public int IdEmployee { get; set; }

    }
}
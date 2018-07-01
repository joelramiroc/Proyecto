// <copyright file="BankViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ProjectSalesCore.ViewModel
{
    using System.Collections.Generic;
    using CSales.Models;

    public class BankDetailViewModel
    {
        public int IdBank { get; set; }

        public string BankName { get; set; }

        public string Description { get; set; }

        public IEnumerable<Telephone> Telephones { get; set; }

        public IEnumerable<Address> Addresses { get; set; }
    }
}
// <copyright file="CreateProviderViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ProjectSalesCore.ViewModel.Provider
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;
    using CSales.Database.Models;
    using ProjectSalesCore.DataBase.Models;

    public class CreateProviderViewModel
    {
        public string Name { get; set; }

        public IEnumerable<string> Addresses { get; set; }

        public IEnumerable<string> Telephones { get; set; }

        public bool IsActive { get; set; }

        public IEnumerable<CityProvider> CitiesDistricts { get; set; }

        public string Contact { get; set; }

        public bool IsForeignProvider { get; set; }

        [ForeignKey(nameof(BusinessName))]
        [Column("BUSINESSNAME")]
        public int IdBusinessName { get; set; }

        [Column("BUSINESSNAME")]
        public virtual BusinessName BusinessName { get; set; }
    }
}
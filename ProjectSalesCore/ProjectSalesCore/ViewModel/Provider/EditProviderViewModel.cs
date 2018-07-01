using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSales.Database.Models;
using ProjectSalesCore.DataBase.Models;

namespace ProjectSalesCore.ViewModel.Provider
{
    public class EditProviderViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<AddressProvider> Addresses { get; set; }

        public IEnumerable<TelephoneProvider> Telephones { get; set; }

        public bool IsActive { get; set; }

        public IEnumerable<CityProvider> CitiesDistricts { get; set; }

        public string Contact { get; set; }

        public bool IsForeignProvider { get; set; }

        public int IdBusinessName { get; set; }

        public virtual BusinessName BusinessName { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
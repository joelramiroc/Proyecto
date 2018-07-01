// <copyright file="CityDistrictRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CSales.Database.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CSales.Database.Contexts;
    using CSales.Database.Models;

    public class CityDistrictRepository : CSalesRepositoryBase<CityDistrict>
    {
        public CityDistrictRepository(MyContext context)
            : base(context)
        {
        }

        public override IQueryable<CityDistrict> All()
        {
            return this.Context.CityDistrict;
        }

        protected override CityDistrict MapNewValuesToOld(CityDistrict oldEntity, CityDistrict newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

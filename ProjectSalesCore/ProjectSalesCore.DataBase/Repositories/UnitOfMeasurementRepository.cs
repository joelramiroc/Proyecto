// <copyright file="UnitOfMeasurementRepository.cs" company="PlaceholderCompany">
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

    public class UnitOfMeasurementRepository : CSalesRepositoryBase<UOfMeasur>
    {
        public UnitOfMeasurementRepository(MyContext context)
            : base(context)
        {
        }

        public override IQueryable<UOfMeasur> All()
        {
            return this.Context.UnitOfMeasurement;
        }

        protected override UOfMeasur MapNewValuesToOld(UOfMeasur oldEntity, UOfMeasur newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

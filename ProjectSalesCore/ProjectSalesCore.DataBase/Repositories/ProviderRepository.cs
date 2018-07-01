// <copyright file="ProviderRepository.cs" company="PlaceholderCompany">
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

    public class ProviderRepository : CSalesRepositoryBase<Provider>
    {
        public ProviderRepository(MyContext context)
            : base(context)
        {
        }

        public override IQueryable<Provider> All()
        {
            return this.Context.Provider;
        }

        protected override Provider MapNewValuesToOld(Provider oldEntity, Provider newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

// <copyright file="CurrentAccountProviderRepository.cs" company="PlaceholderCompany">
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

    public class CurrentAccountProviderRepository : CSalesRepositoryBase<CurrentAccountProvider>
    {
        public CurrentAccountProviderRepository(MyContext context) : base(context)
        {
        }

        public override IQueryable<CurrentAccountProvider> All()
        {
            throw new NotImplementedException();
        }

        protected override CurrentAccountProvider MapNewValuesToOld(CurrentAccountProvider oldEntity, CurrentAccountProvider newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

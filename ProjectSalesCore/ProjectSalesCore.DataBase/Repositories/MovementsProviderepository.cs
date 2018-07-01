// <copyright file="MovementsProviderepository.cs" company="PlaceholderCompany">
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

    public class MovementsProviderepository : CSalesRepositoryBase<MovementsProvider>
    {
        public MovementsProviderepository(MyContext context)
            : base(context)
        {
        }

        public override IQueryable<MovementsProvider> All()
        {
            return this.Context.MovementsProvider;
        }

        protected override MovementsProvider MapNewValuesToOld(MovementsProvider oldEntity, MovementsProvider newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

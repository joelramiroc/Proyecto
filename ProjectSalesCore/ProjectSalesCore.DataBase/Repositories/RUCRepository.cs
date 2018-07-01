// <copyright file="RUCRepository.cs" company="PlaceholderCompany">
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

    public class RUCRepository : CSalesRepositoryBase<RUC>
    {
        public RUCRepository(MyContext context)
            : base(context)
        {
        }

        public override IQueryable<RUC> All()
        {
            return this.Context.RUC;
        }

        protected override RUC MapNewValuesToOld(RUC oldEntity, RUC newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

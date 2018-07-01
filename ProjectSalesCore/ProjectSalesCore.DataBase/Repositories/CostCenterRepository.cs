// <copyright file="CostCenterRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CSales.Database.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Contexts;
    using Models;

    public class CostCenterRepository : CSalesRepositoryBase<CostCenter>
    {
        public CostCenterRepository(MyContext context)
            : base(context)
        {
        }

        public override IQueryable<CostCenter> All()
        {
            return this.Context.CostCenter;
        }

        protected override CostCenter MapNewValuesToOld(CostCenter oldEntity, CostCenter newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

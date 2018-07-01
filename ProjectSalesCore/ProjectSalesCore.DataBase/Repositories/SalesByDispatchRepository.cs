// <copyright file="SalesByDispatchRepository.cs" company="PlaceholderCompany">
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

    public class SalesByDispatchRepository : CSalesRepositoryBase<SaByDisp>
    {
        public SalesByDispatchRepository(MyContext context)
            : base(context)
        {
        }

        public override IQueryable<SaByDisp> All()
        {
            return this.Context.SalesByDispatch;
        }

        protected override SaByDisp MapNewValuesToOld(SaByDisp oldEntity, SaByDisp newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

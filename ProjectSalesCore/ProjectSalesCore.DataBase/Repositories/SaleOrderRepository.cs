// <copyright file="SaleOrderRepository.cs" company="PlaceholderCompany">
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

    public class SaleOrderRepository : CSalesRepositoryBase<SaleOrder>
    {
        public SaleOrderRepository(MyContext context) : base(context)
        {
        }

        public override IQueryable<SaleOrder> All()
        {
            return this.Context.SaleOrder;
        }

        protected override SaleOrder MapNewValuesToOld(SaleOrder oldEntity, SaleOrder newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

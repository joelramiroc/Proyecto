// <copyright file="BillOfExchangeRepository.cs" company="PlaceholderCompany">
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

    public class BillOfExchangeRepository : CSalesRepositoryBase<BillOfExchange>
    {
        public BillOfExchangeRepository(MyContext context)
            : base(context)
        {
        }

        public override IQueryable<BillOfExchange> All()
        {
            return this.Context.BillOfExchange;
        }

        protected override BillOfExchange MapNewValuesToOld(BillOfExchange oldEntity, BillOfExchange newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

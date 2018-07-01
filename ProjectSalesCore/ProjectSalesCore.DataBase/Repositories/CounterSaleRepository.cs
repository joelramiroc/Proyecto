// <copyright file="CounterSaleRepository.cs" company="PlaceholderCompany">
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

    public class CounterSaleRepository : CSalesRepositoryBase<CounterSale>
    {
        public CounterSaleRepository(MyContext context)
            : base(context)
        {
        }

        public override IQueryable<CounterSale> All()
        {
            return this.Context.CounterSale;
        }

        protected override CounterSale MapNewValuesToOld(CounterSale oldEntity, CounterSale newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

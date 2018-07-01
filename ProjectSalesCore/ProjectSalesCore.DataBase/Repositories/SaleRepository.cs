// <copyright file="SaleRepository.cs" company="PlaceholderCompany">
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

    public class SaleRepository : CSalesRepositoryBase<Sale>
    {
        public SaleRepository(MyContext context)
            : base(context)
        {
        }

        public override IQueryable<Sale> All()
        {
            return this.Context.Sale;
        }

        protected override Sale MapNewValuesToOld(Sale oldEntity, Sale newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

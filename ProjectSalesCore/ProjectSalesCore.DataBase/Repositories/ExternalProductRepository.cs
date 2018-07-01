// <copyright file="ExternalProductRepository.cs" company="PlaceholderCompany">
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

    public class ExternalProductRepository : CSalesRepositoryBase<EProduct>
    {
        public ExternalProductRepository(MyContext context)
            : base(context)
        {
        }

        public override IQueryable<EProduct> All()
        {
            return this.Context.ExternalProduct;
        }

        protected override EProduct MapNewValuesToOld(EProduct oldEntity, EProduct newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

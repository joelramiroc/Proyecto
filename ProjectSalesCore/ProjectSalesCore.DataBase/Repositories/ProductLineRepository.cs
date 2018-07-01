// <copyright file="ProductLineRepository.cs" company="PlaceholderCompany">
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

    public class ProductLineRepository : CSalesRepositoryBase<ProductLine>
    {
        public ProductLineRepository(MyContext context)
            : base(context)
        {
        }

        public override IQueryable<ProductLine> All()
        {
            return this.Context.ProductLine;
        }

        protected override ProductLine MapNewValuesToOld(ProductLine oldEntity, ProductLine newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

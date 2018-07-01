// <copyright file="ProductTypeRepository.cs" company="PlaceholderCompany">
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

    public class ProductTypeRepository : CSalesRepositoryBase<ProductType>
    {
        public ProductTypeRepository(MyContext context)
            : base(context)
        {
        }

        public override IQueryable<ProductType> All()
        {
            return this.Context.ProductType;
        }

        protected override ProductType MapNewValuesToOld(ProductType oldEntity, ProductType newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

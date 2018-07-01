// <copyright file="ProductRepository.cs" company="PlaceholderCompany">
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

    public class ProductRepository : CSalesRepositoryBase<Product>
    {
        public ProductRepository(MyContext context)
            : base(context)
        {
        }

        public override IQueryable<Product> All()
        {
            return this.Context.Product;
        }

        protected override Product MapNewValuesToOld(Product oldEntity, Product newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

// <copyright file="InternalProductRepository.cs" company="PlaceholderCompany">
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

    public class InternalProductRepository : CSalesRepositoryBase<IProduct>
    {
        public InternalProductRepository(MyContext context)
            : base(context)
        {
        }

        public override IQueryable<IProduct> All()
        {
            return this.Context.InternalProduct;
        }

        protected override IProduct MapNewValuesToOld(IProduct oldEntity, IProduct newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

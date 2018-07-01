// <copyright file="DetailsProductsToSaleRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CSales.Database.Repositories
{
    using System;
    using System.Linq;
    using Contexts;
    using Models;

    public class DetailsProductsToSaleRepository : CSalesRepositoryBase<DPToSale>
    {
        public DetailsProductsToSaleRepository(MyContext context)
            : base(context)
        {
        }

        public override IQueryable<DPToSale> All()
        {
            return this.Context.DetailsProductsToSale;
        }

        protected override DPToSale MapNewValuesToOld(DPToSale oldEntity, DPToSale newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

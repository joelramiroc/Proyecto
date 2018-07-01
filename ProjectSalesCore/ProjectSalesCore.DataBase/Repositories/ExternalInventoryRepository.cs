// <copyright file="ExternalInventoryRepository.cs" company="PlaceholderCompany">
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

    public class ExternalInventoryRepository : CSalesRepositoryBase<ExternalInventory>
    {
        public ExternalInventoryRepository(MyContext context)
            : base(context)
        {
        }

        public override IQueryable<ExternalInventory> All()
        {
            return this.Context.ExternalInventory;
        }

        protected override ExternalInventory MapNewValuesToOld(ExternalInventory oldEntity, ExternalInventory newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

// <copyright file="InternalInventoryRepository.cs" company="PlaceholderCompany">
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

    public class InternalInventoryRepository : CSalesRepositoryBase<InternalInventory>
    {
        public InternalInventoryRepository(MyContext context)
            : base(context)
        {
        }

        public override IQueryable<InternalInventory> All()
        {
            return this.Context.InternalInventory;
        }

        protected override InternalInventory MapNewValuesToOld(InternalInventory oldEntity, InternalInventory newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

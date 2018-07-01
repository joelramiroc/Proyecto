// <copyright file="CollectionRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CSales.Database.Repositories
{
    using System;
    using System.Linq;
    using CSales.Database.Contexts;
    using CSales.Database.Models;

    public class CollectionRepository : CSalesRepositoryBase<Collection>
    {
        public CollectionRepository(MyContext context)
            : base(context)
        {
        }

        public override IQueryable<Collection> All()
        {
            return this.Context.Collection;
        }

        protected override Collection MapNewValuesToOld(Collection oldEntity, Collection newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

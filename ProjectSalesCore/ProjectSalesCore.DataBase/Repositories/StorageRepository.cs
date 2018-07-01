// <copyright file="StorageRepository.cs" company="PlaceholderCompany">
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

    public class StorageRepository : CSalesRepositoryBase<Storage>
    {
        public StorageRepository(MyContext context)
            : base(context)
        {
        }

        public override IQueryable<Storage> All()
        {
            return this.Context.Storage;
        }

        protected override Storage MapNewValuesToOld(Storage oldEntity, Storage newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

// <copyright file="KardexRepository.cs" company="PlaceholderCompany">
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

    public class KardexRepository : CSalesRepositoryBase<Kardex>
    {
        public KardexRepository(MyContext context)
            : base(context)
        {
        }

        public override IQueryable<Kardex> All()
        {
            return this.Context.Kardex;
        }

        protected override Kardex MapNewValuesToOld(Kardex oldEntity, Kardex newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

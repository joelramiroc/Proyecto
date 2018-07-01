// <copyright file="ChekRepository.cs" company="PlaceholderCompany">
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

    public class ChekRepository : CSalesRepositoryBase<Check>
    {
        public ChekRepository(MyContext context) : base(context)
        {
        }

        public override IQueryable<Check> All()
        {
            return this.Context.Chek;
        }

        protected override Check MapNewValuesToOld(Check oldEntity, Check newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

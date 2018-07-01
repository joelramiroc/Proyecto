// <copyright file="FaxRepository.cs" company="PlaceholderCompany">
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

    public class FaxRepository : CSalesRepositoryBase<Fax>
    {
        public FaxRepository(MyContext context)
            : base(context)
        {
        }

        public override IQueryable<Fax> All()
        {
            return this.Context.Fax;
        }

        protected override Fax MapNewValuesToOld(Fax oldEntity, Fax newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

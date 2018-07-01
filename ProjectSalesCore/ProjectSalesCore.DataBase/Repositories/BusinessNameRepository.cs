// <copyright file="BusinessNameRepository.cs" company="PlaceholderCompany">
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

    public class BusinessNameRepository : CSalesRepositoryBase<BusinessName>
    {
        public BusinessNameRepository(MyContext context)
            : base(context)
        {
        }

        public override IQueryable<BusinessName> All()
        {
            return this.Context.BusinessName;
        }

        protected override BusinessName MapNewValuesToOld(BusinessName oldEntity, BusinessName newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

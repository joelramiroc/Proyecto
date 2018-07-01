// <copyright file="BillRepository.cs" company="PlaceholderCompany">
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

    public class BillRepository : CSalesRepositoryBase<Bill>
    {
        public BillRepository(MyContext context)
            : base(context)
        {
        }

        public override IQueryable<Bill> All()
        {
            return this.Context.Bill;
        }

        protected override Bill MapNewValuesToOld(Bill oldEntity, Bill newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

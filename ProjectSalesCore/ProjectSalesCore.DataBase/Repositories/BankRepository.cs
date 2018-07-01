// <copyright file="BankRepository.cs" company="PlaceholderCompany">
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

    public class BankRepository : CSalesRepositoryBase<Bank>
    {
        public BankRepository(MyContext context)
            : base(context)
        {
        }

        public override IQueryable<Bank> All()
        {
            return this.Context.Bank;
        }

        protected override Bank MapNewValuesToOld(Bank oldEntity, Bank newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

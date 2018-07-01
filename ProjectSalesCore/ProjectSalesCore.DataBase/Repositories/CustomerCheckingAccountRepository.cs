// <copyright file="CustomerCheckingAccountRepository.cs" company="PlaceholderCompany">
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

    public class CustomerCheckingAccountRepository : CSalesRepositoryBase<CustomerCheckingAccount>
    {
        public CustomerCheckingAccountRepository(MyContext context)
            : base(context)
        {
        }

        public override IQueryable<CustomerCheckingAccount> All()
        {
            return this.Context.CustomerCheckingAccount;
        }

        protected override CustomerCheckingAccount MapNewValuesToOld(CustomerCheckingAccount oldEntity, CustomerCheckingAccount newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

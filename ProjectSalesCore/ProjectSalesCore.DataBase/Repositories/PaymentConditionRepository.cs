// <copyright file="PaymentConditionRepository.cs" company="PlaceholderCompany">
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

    public class PaymentConditionRepository : CSalesRepositoryBase<PCondition>
    {
        public PaymentConditionRepository(MyContext context)
            : base(context)
        {
        }

        public override IQueryable<PCondition> All()
        {
            return this.Context.PaymentCondition;
        }

        protected override PCondition MapNewValuesToOld(PCondition oldEntity, PCondition newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

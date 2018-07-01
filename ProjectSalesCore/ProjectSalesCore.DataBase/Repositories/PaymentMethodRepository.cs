// <copyright file="PaymentMethodRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CSales.Database.Repositories
{
    using System;
    using System.Linq;
    using CSales.Database.Contexts;
    using CSales.Database.Models;

    public class PaymentMethodRepository : CSalesRepositoryBase<PaymentMethod>
    {
        public PaymentMethodRepository(MyContext context) : base(context)
        {
        }

        public override IQueryable<PaymentMethod> All()
        {
            return this.Context.PaymentMethod;
        }

        protected override PaymentMethod MapNewValuesToOld(PaymentMethod oldEntity, PaymentMethod newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

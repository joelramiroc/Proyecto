// <copyright file="VoucherRepository.cs" company="PlaceholderCompany">
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

    public class VoucherRepository : CSalesRepositoryBase<Voucher>
    {
        public VoucherRepository(MyContext context)
            : base(context)
        {
        }

        public override IQueryable<Voucher> All()
        {
            return this.Context.Voucher;
        }

        protected override Voucher MapNewValuesToOld(Voucher oldEntity, Voucher newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

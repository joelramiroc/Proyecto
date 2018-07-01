// <copyright file="PurchaseDocumentRepository.cs" company="PlaceholderCompany">
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

    public class PurchaseDocumentRepository : CSalesRepositoryBase<PDoc>
    {
        public PurchaseDocumentRepository(MyContext context)
            : base(context)
        {
        }

        public override IQueryable<PDoc> All()
        {
            return this.Context.PurchaseDocument;
        }

        protected override PDoc MapNewValuesToOld(PDoc oldEntity, PDoc newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

// <copyright file="TypeOfPuchaseDocumentRepository.cs" company="PlaceholderCompany">
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

    public class TypeOfPuchaseDocumentRepository : CSalesRepositoryBase<TOPDoc>
    {
        public TypeOfPuchaseDocumentRepository(MyContext context)
            : base(context)
        {
        }

        public override IQueryable<TOPDoc> All()
        {
            return this.Context.TypeOfPurchaseDocument;
        }

        protected override TOPDoc MapNewValuesToOld(TOPDoc oldEntity, TOPDoc newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

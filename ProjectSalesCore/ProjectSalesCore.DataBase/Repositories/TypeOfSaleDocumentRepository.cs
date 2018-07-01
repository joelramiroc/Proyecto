// <copyright file="TypeOfSaleDocumentRepository.cs" company="PlaceholderCompany">
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

    public class TypeOfSaleDocumentRepository : CSalesRepositoryBase<TOSDoc>
    {
        public TypeOfSaleDocumentRepository(MyContext context)
            : base(context)
        {
        }

        public override IQueryable<TOSDoc> All()
        {
            return this.Context.TypeOfSaleDocument;
        }

        protected override TOSDoc MapNewValuesToOld(TOSDoc oldEntity, TOSDoc newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

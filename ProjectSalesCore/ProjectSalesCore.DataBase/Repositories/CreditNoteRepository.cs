// <copyright file="CreditNoteRepository.cs" company="PlaceholderCompany">
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

    public class CreditNoteRepository : CSalesRepositoryBase<CreditNote>
    {
        public CreditNoteRepository(MyContext context)
            : base(context)
        {
        }

        public override IQueryable<CreditNote> All()
        {
            return this.Context.CreditNote;
        }

        protected override CreditNote MapNewValuesToOld(CreditNote oldEntity, CreditNote newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

// <copyright file="CreditNoteTypeRepository.cs" company="PlaceholderCompany">
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

    public class CreditNoteTypeRepository : CSalesRepositoryBase<CreditNoteType>
    {
        public CreditNoteTypeRepository(MyContext context)
            : base(context)
        {
        }

        public override IQueryable<CreditNoteType> All()
        {
            return this.Context.CreditNoteType;
        }

        protected override CreditNoteType MapNewValuesToOld(CreditNoteType oldEntity, CreditNoteType newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

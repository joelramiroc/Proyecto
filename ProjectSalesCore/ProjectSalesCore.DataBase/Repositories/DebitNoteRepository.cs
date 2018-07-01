// <copyright file="DebitNoteRepository.cs" company="PlaceholderCompany">
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

    public class DebitNoteRepository : CSalesRepositoryBase<DebitNote>
    {
        public DebitNoteRepository(MyContext context)
            : base(context)
        {
        }

        public override IQueryable<DebitNote> All()
        {
            return this.Context.DebitNote;
        }

        protected override DebitNote MapNewValuesToOld(DebitNote oldEntity, DebitNote newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

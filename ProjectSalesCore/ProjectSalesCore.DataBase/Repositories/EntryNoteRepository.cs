// <copyright file="EntryNoteRepository.cs" company="PlaceholderCompany">
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

    public class EntryNoteRepository : CSalesRepositoryBase<EntryNote>
    {
        public EntryNoteRepository(MyContext context)
            : base(context)
        {
        }

        public override IQueryable<EntryNote> All()
        {
            return this.Context.EntryNote;
        }

        protected override EntryNote MapNewValuesToOld(EntryNote oldEntity, EntryNote newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

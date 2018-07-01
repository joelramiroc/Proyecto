// <copyright file="DetailEntryNoteRepository.cs" company="PlaceholderCompany">
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

    public class DetailEntryNoteRepository : CSalesRepositoryBase<DetailEntryNote>
    {
        public DetailEntryNoteRepository(MyContext context)
            : base(context)
        {
        }

        public override IQueryable<DetailEntryNote> All()
        {
            return this.Context.DetailEntryNote;
        }

        protected override DetailEntryNote MapNewValuesToOld(DetailEntryNote oldEntity, DetailEntryNote newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

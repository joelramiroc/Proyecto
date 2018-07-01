// <copyright file="ReasonNoteRepository.cs" company="PlaceholderCompany">
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

    public class ReasonNoteRepository : CSalesRepositoryBase<ReasonNote>
    {
        public ReasonNoteRepository(MyContext context)
            : base(context)
        {
        }

        public override IQueryable<ReasonNote> All()
        {
            return this.Context.ReasonNote;
        }

        protected override ReasonNote MapNewValuesToOld(ReasonNote oldEntity, ReasonNote newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

// <copyright file="StatusNoteRepository.cs" company="PlaceholderCompany">
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

    public class StatusNoteRepository : CSalesRepositoryBase<StatusNote>
    {
        public StatusNoteRepository(MyContext context)
            : base(context)
        {
        }

        public override IQueryable<StatusNote> All()
        {
            return this.Context.StatusNote;
        }

        protected override StatusNote MapNewValuesToOld(StatusNote oldEntity, StatusNote newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

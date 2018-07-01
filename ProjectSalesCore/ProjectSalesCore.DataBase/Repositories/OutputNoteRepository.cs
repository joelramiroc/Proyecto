// <copyright file="OutputNoteRepository.cs" company="PlaceholderCompany">
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

    public class OutputNoteRepository : CSalesRepositoryBase<OutputNote>
    {
        public OutputNoteRepository(MyContext context)
            : base(context)
        {
        }

        public override IQueryable<OutputNote> All()
        {
            return this.Context.OuputNote;
        }

        protected override OutputNote MapNewValuesToOld(OutputNote oldEntity, OutputNote newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

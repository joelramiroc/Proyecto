// <copyright file="CurrentAccountDocumentTypeRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CSales.Database.Repositories
{
    using System;
    using System.Linq;
    using Contexts;
    using Models;

    public class CurrentAccountDocumentTypeRepository : CSalesRepositoryBase<CurrentAccountDocumentType>
    {
        public CurrentAccountDocumentTypeRepository(MyContext context)
            : base(context)
        {
        }

        public override IQueryable<CurrentAccountDocumentType> All()
        {
            return this.Context.CurrentAccountDocumentType;
        }

        protected override CurrentAccountDocumentType MapNewValuesToOld(CurrentAccountDocumentType oldEntity, CurrentAccountDocumentType newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

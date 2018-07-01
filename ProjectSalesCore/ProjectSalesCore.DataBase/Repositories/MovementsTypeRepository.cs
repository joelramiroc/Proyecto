// <copyright file="MovementsTypeRepository.cs" company="PlaceholderCompany">
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
    using Models;

    public class MovementsTypeRepository : CSalesRepositoryBase<MovementType>
    {
        public MovementsTypeRepository(MyContext context)
            : base(context)
        {
        }

        public override IQueryable<MovementType> All()
        {
            return this.Context.MovementType;
        }

        protected override MovementType MapNewValuesToOld(MovementType oldEntity, MovementType newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

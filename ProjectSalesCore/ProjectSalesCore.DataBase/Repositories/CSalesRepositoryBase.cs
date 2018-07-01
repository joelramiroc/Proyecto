// <copyright file="CSalesRepositoryBase.cs" company="PlaceholderCompany">
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

    public abstract class CSalesRepositoryBase<TEntity> : RepositoryBase<TEntity, MyContext>
        where TEntity : class
    {
        public CSalesRepositoryBase(MyContext context)
            : base(context)
        {
            this.Context = context;
        }
    }
}

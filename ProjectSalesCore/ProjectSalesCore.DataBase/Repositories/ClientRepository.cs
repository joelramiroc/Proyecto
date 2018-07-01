// <copyright file="ClientRepository.cs" company="PlaceholderCompany">
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

    public class ClientRepository : CSalesRepositoryBase<Client>
    {
        public ClientRepository(MyContext context)
            : base(context)
        {
        }

        public override IQueryable<Client> All()
        {
            return this.Context.Client;
        }

        protected override Client MapNewValuesToOld(Client oldEntity, Client newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

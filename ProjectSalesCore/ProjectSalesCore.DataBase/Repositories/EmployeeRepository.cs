// <copyright file="EmployeeRepository.cs" company="PlaceholderCompany">
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

    public class EmployeeRepository : CSalesRepositoryBase<Employee>
    {
        public EmployeeRepository(MyContext context)
            : base(context)
        {
        }

        public override IQueryable<Employee> All()
        {
            return this.Context.Employee;
        }

        protected override Employee MapNewValuesToOld(Employee oldEntity, Employee newEntity)
        {
            throw new NotImplementedException();
        }
    }
}

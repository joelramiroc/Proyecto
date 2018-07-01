// <copyright file="Configuration.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ProjectSalesCore.DataBase.Migrations.FireBird
{
    using System.Data.Entity.Migrations;
    using System.Data.Entity.SqlServer;
    using CSales.Database.Contexts;
    using ProjectSalesCore.Migrations.Seed;

    public class Configuration : DbMigrationsConfiguration<MyContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.SetSqlGenerator("FirebirdSql.Data.FirebirdClient", new SqlServerMigrationSqlGenerator());
        }

        protected override void Seed(MyContext myContext)
        {
            DataProductionSeed.Seed(myContext);
            myContext.SaveChanges();
        }
    }
}

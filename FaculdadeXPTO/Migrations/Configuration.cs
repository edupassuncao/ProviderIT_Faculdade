namespace FaculdadeXPTO.Migrations
{
    using FaculdadeXPTO.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FaculdadeXPTO.DAL.Contexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;            
            
        }

        protected override void Seed(FaculdadeXPTO.DAL.Contexto context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            
        }
    }
}

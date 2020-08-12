namespace Gosh.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Gosh.Models.MyDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Gosh.Models.MyDB context)
        {
            //  This method will be called after migrating to the latest version.

            AddCategories(context);
            
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }


        void AddCategories(Gosh.Models.MyDB context)
        {
            //context.Categories.Add(new Models.Category(.....))
        }
    }
}

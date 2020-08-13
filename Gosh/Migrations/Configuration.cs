namespace Gosh.Migrations
{
    using Gosh.Controllers;
    using Gosh.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.UI;

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
            CreateAdmin();
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    

        void CreateAdmin()
        {
            User admin = new User();
            admin.FirstName = "Admin";
            admin.LastName = "Admin";
            admin.Password = "Aa123456!";
            admin.ConfirmPassword = "Aa123456!";
            admin.Mail = "admin@gosh.com";
            admin.PhoneNumber = "+972-557-0555-12";
            admin.Username = "admin";
            new UserController().Register(admin, admin.Password, admin.ConfirmPassword);
        }

        void AddCategories(Gosh.Models.MyDB context)
        {
            //context.Categories.Add(new Models.Category(.....))
        }
    }
}

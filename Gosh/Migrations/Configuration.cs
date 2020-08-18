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

            context.Categories.AddOrUpdate(new Category()
            {
                CategoryName = "Italiano",
                ImagePath = "Italiano.jpg",
                RepresetingArea = "Italy",
                WeatherHref = "/41d9012d50/rome/"
            });


            context.Categories.AddOrUpdate(new Category()
            {
                CategoryName = "French",
                ImagePath = "French.jpg",
                RepresetingArea = "France", 
                WeatherHref = "/48d862d35/paris/"
            });

            context.Categories.AddOrUpdate(new Category()
            {
                CategoryName = "Israeli",
                ImagePath = "Israeli.jpg",
                RepresetingArea = "Israel", 
                WeatherHref = "/31d7735d21/jerusalem/"
            });

            
            context.Categories.AddOrUpdate(new Category()
            {
                CategoryName = "Japanese",
                ImagePath = "Japanese.jpg",
                RepresetingArea = "Japan", 
                WeatherHref = "/35d71139d73/tokyo/"
            });

            context.Categories.AddOrUpdate(new Category()
            {
                CategoryName = "Brazilian",
                ImagePath = "Brazilian.jpg",
                RepresetingArea = "Brazil",
                WeatherHref = "/n22d91n43d17/rio-de-janeiro/"
            });

            context.Categories.AddOrUpdate(new Category()
            {
                CategoryName = "Russian",
                ImagePath = "Russian.jpg",
                RepresetingArea = "Russia",
                WeatherHref = "/55d7637d62/moscow/"
            });

            context.Categories.AddOrUpdate(new Category()
            {
                CategoryName = "Greek",
                ImagePath = "Greek.jpg",
                RepresetingArea = "Greece",
                WeatherHref = "/39d0721d82/greece/"
            });

            context.Categories.AddOrUpdate(new Category()
            {
                CategoryName = "Australian",
                ImagePath = "Australian.jpg",
                RepresetingArea = "Australia",
                WeatherHref = "/n33d87151d21/sydney/"
            });
            context.Categories.AddOrUpdate(new Category()
            {
                CategoryName = "Chinese",
                ImagePath = "Chinese.jpg",
                RepresetingArea = "China",
                WeatherHref = "/31d23121d47/shanghai/"
            });
        }
    }
}

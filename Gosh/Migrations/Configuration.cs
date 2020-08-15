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
            Category Italiano = new Category();
            Italiano.CategoryName = "Italiano";
            Italiano.ImagePath = "Italiano.jpg";
            new CategoriesController().Create(Italiano, null);

            Category French = new Category();
            French.CategoryName = "French";
            French.ImagePath = "French.jpg";
            new CategoriesController().Create(French, null);

            Category Israeli = new Category();
            Israeli.CategoryName = "Israeli";
            Israeli.ImagePath = "Israeli.jpg";
            new CategoriesController().Create(Israeli, null);

            Category Japanese = new Category();
            Japanese.CategoryName = "Japanese";
            Japanese.ImagePath = "Japanese.jpg";
            new CategoriesController().Create(Japanese, null);

            Category Brazilian = new Category();
            Brazilian.CategoryName = "Brazilian";
            Brazilian.ImagePath = "Brazilian.jpg";
            new CategoriesController().Create(Brazilian, null);

            Category Russian = new Category();
            Russian.CategoryName = "Russian";
            Russian.ImagePath = "Russian.jpg";
            new CategoriesController().Create(Russian, null);

            Category Greek = new Category();
            Greek.CategoryName = "Greek";
            Greek.ImagePath = "Greek.jpg";
            new CategoriesController().Create(Greek, null);

            Category Australian = new Category();
            Australian.CategoryName = "Australian";
            Australian.ImagePath = "Australian.jpg";
            new CategoriesController().Create(Australian, null);

            Category Chinese = new Category();
            Chinese.CategoryName = "Chinese";
            Chinese.ImagePath = "Chinese.jpg";
            new CategoriesController().Create(Chinese, null);
        }
    }
}

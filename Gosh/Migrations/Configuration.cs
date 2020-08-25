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
            AddRecipies(context);
            AddUserRecipePreference(context);
            CreateAdmin(context);
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }


        void CreateAdmin(Gosh.Models.MyDB context)
        {
            User admin = new User();
            admin.FirstName = "Admin";
            admin.LastName = "Admin";
            admin.Password = "Aa123456!";
            admin.ConfirmPassword = "Aa123456!";
            admin.Mail = "admin@gosh.com";
            admin.PhoneNumber = "+972-557-0555-12";
            admin.Username = "admin";
            Password p = Password.Create(admin.Password);
            p.UserID = admin.ID;
            p.User = admin;

            context.Users.AddOrUpdate(admin);
            context.Passwords.AddOrUpdate(p);



        }

        void AddCategories(Gosh.Models.MyDB context)
        {

            context.Categories.AddOrUpdate(new Category()
            {
                CategoryName = "Italiano",
                ImagePath = "Italiano.jpg",
                RepresetingArea = "Italy",
                WeatherHref = "/41d9012d50/rome/",
                ID = 1
            });


            context.Categories.AddOrUpdate(new Category()
            {
                CategoryName = "French",
                ImagePath = "French.jpg",
                RepresetingArea = "France",
                WeatherHref = "/48d862d35/paris/",
                ID = 2
            });

            context.Categories.AddOrUpdate(new Category()
            {
                CategoryName = "Israeli",
                ImagePath = "Israeli.jpg",
                RepresetingArea = "Israel",
                WeatherHref = "/31d7735d21/jerusalem/",
                ID = 3
            });


            context.Categories.AddOrUpdate(new Category()
            {
                CategoryName = "Japanese",
                ImagePath = "Japanese.jpg",
                RepresetingArea = "Japan",
                WeatherHref = "/35d71139d73/tokyo/",
                ID = 4
            });

            context.Categories.AddOrUpdate(new Category()
            {
                CategoryName = "Brazilian",
                ImagePath = "Brazilian.jpg",
                RepresetingArea = "Brazil",
                WeatherHref = "/n22d91n43d17/rio-de-janeiro/",
                ID = 5
            });

            context.Categories.AddOrUpdate(new Category()
            {
                CategoryName = "Russian",
                ImagePath = "Russian.jpg",
                RepresetingArea = "Russia",
                WeatherHref = "/55d7637d62/moscow/",
                ID = 6
            });

            context.Categories.AddOrUpdate(new Category()
            {
                CategoryName = "Greek",
                ImagePath = "Greek.jpg",
                RepresetingArea = "Greece",
                WeatherHref = "/39d0721d82/greece/",
                ID = 7
            });

            context.Categories.AddOrUpdate(new Category()
            {
                CategoryName = "Australian",
                ImagePath = "Australian.jpg",
                RepresetingArea = "Australia",
                WeatherHref = "/n33d87151d21/sydney/",
                ID = 8
            });
            context.Categories.AddOrUpdate(new Category()
            {
                CategoryName = "Chinese",
                ImagePath = "Chinese.jpg",
                RepresetingArea = "China",
                WeatherHref = "/31d23121d47/shanghai/",
                ID = 9
            });
        }

        void AddRecipies(Gosh.Models.MyDB context)
        {
            context.Recipes.AddOrUpdate(new Recipe()
            {
                CategoryId = 2,
                DateCreated = DateTime.Now,
                Summary = "Test recipe 1",
                Header = "Test recipe 1",
                Content = "Test recipe 1",
                HomeImageUrl = null,
                RecipeId = 1
            });

            context.Recipes.AddOrUpdate(new Recipe()
            {
                CategoryId = 2,
                DateCreated = DateTime.Now,
                Summary = "Test recipe 2",
                Header = "Test recipe 2",
                Content = "Test recipe 2",
                HomeImageUrl = null,
                RecipeId = 2
            });
            context.Recipes.AddOrUpdate(new Recipe()
            {
                CategoryId = 1,
                DateCreated = DateTime.Now,
                Summary = "Test recipe 3",
                Header = "Test recipe 3",
                Content = "Test recipe 3",
                HomeImageUrl = null,
                RecipeId = 3
            });
            context.Recipes.AddOrUpdate(new Recipe()
            {
                CategoryId = 3,
                DateCreated = DateTime.Now,
                Summary = "Test recipe 4",
                Header = "Test recipe 4",
                Content = "Test recipe 4",
                HomeImageUrl = null,
                RecipeId = 4
            });


            context.Recipes.AddOrUpdate(new Recipe()
            {
                CategoryId = 4,
                DateCreated = DateTime.Now,
                Summary = "Test recipe 5",
                Header = "Test recipe 5",
                Content = "Test recipe 5",
                HomeImageUrl = null,
                RecipeId = 5
            });
        }

        void AddUserRecipePreference(Gosh.Models.MyDB context)
        {
            long ID = 1;
            context.userRecipePreferences.AddOrUpdate(new Models.UserRecipePreference()
            {
                RecipeID = 1,
                UserID = 1,
                ID = ID++
            });

            context.userRecipePreferences.AddOrUpdate(new Models.UserRecipePreference()
            {
                RecipeID = 1,
                UserID = 1,
                ID = ID++
            });

            context.userRecipePreferences.AddOrUpdate(new Models.UserRecipePreference()
            {
                RecipeID = 2,
                UserID = 1,
                ID = ID++
            });

            context.userRecipePreferences.AddOrUpdate(new Models.UserRecipePreference()
            {
                RecipeID = 3,
                UserID = 1,
                ID = ID++
            });
            context.userRecipePreferences.AddOrUpdate(new Models.UserRecipePreference()
            {
                RecipeID = 4,
                UserID = 1,
                ID = ID++
            });
            context.userRecipePreferences.AddOrUpdate(new Models.UserRecipePreference()
            {
                RecipeID = 4,
                UserID = 1,
                ID = ID++
            });
            context.userRecipePreferences.AddOrUpdate(new Models.UserRecipePreference()
            {
                RecipeID = 4,
                UserID = 1,
                ID = ID++
            });
            context.userRecipePreferences.AddOrUpdate(new Models.UserRecipePreference()
            {
                RecipeID = 4,
                UserID = 1,
                ID = ID++
            });
            context.userRecipePreferences.AddOrUpdate(new Models.UserRecipePreference()
            {
                RecipeID = 4,
                UserID = 1,
                ID = ID++
            });
            context.userRecipePreferences.AddOrUpdate(new Models.UserRecipePreference()
            {
                RecipeID = 4,
                UserID = 1,
                ID = ID++
            });

            context.userRecipePreferences.AddOrUpdate(new Models.UserRecipePreference()
            {
                RecipeID = 4,
                UserID = 1,
                ID = ID++
            });
            context.userRecipePreferences.AddOrUpdate(new Models.UserRecipePreference()
            {
                RecipeID = 5,
                UserID = 1,
                ID = ID++
            });
            context.userRecipePreferences.AddOrUpdate(new Models.UserRecipePreference()
            {
                RecipeID = 5,
                UserID = 1,
                ID = ID++
            });
            context.userRecipePreferences.AddOrUpdate(new Models.UserRecipePreference()
            {
                RecipeID = 5,
                UserID = 1,
                ID = ID++
            });
            context.userRecipePreferences.AddOrUpdate(new Models.UserRecipePreference()
            {
                RecipeID = 5,
                UserID = 1,
                ID = ID++
            });


        }
    }
}

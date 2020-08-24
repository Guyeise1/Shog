using Gosh.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace Gosh.Controllers.Statistics
{
    public class RecipeLearning
    {

        private MyDB db = new MyDB();

        /// <summary>
        /// This function should be called every time a user press on a recipe to improve
        /// future suggestions.
        /// </summary>
        /// <param name="UserID">
        /// The user who clicked
        /// </param>
        /// 
        /// <param name="RecipeID">
        /// The recipe
        /// </param>
        ///
        public void SavePreference(long UserID, int RecipeID)
        {
            db.userRecipePreferences.Add(new UserRecipePreference()
            {
                RecipeID = RecipeID,
                UserID = UserID
            });

            db.SaveChanges();
        }

        /// <summary>
        /// Gets recommended recipes based on the user preference
        /// </summary>
        /// <param name="UserID">
        /// The user
        /// </param>
        /// <param name="count">
        /// Maximum of categories to recive
        /// </param>
        /// <returns></returns>
        public List<Category> RecommendedForYou(long UserID, int count)
        {
            List<Category> ret = null;

            // db.userRecipePreferences.Where(x => x.UserID == usr.ID).GroupBy(x => x.Recipe.CategoryId).Select( )
            var query = from p in db.userRecipePreferences
                        where p.UserID == UserID
                        group p by p.Recipe.CategoryId into g
                        orderby count
                        select new
                        {
                            categoryID = g.Key,
                            count = g.Count()
                        };

            var lst = query.ToList();

            ret = new List<Category>();
            for (int i = 0; i < count; i++)
            {
                if(i < lst.Count)
                {
                    int CategoryID = lst[i].categoryID;
                    Category c = db.Categories.Where(x => x.ID == CategoryID).First();
                    ret.Add(c);
                }
            }
            return ret;
        }
    }
}
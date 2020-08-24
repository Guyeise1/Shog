using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Gosh.Models
{
    /// <summary>
    /// This class is for statistics about userpreferences of recipes.
    /// Every time a user clicks on a recipe a new row of this model inserted into
    /// the database.
    /// </summary>
    public class UserRecipePreference
    {
        public long ID { get; set; }

        [ForeignKey("User")]
        public long UserID { get; set; }

        public User User { get; set; }

        [ForeignKey("Recipe")]
        public int RecipeID { get; set; }

        public Recipe Recipe { get; set; }
    }
}
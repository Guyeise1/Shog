using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gosh.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }

        [DisplayName("Creation Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateCreated { get; set; }

        [DisplayName("Recipe Name")]
        public string Header { get; set; }

        public string Summary { get; set; }

        [DisplayName("Recipe Ingredients & Directions ")]
        public string Content { get; set; }

        public string HomeImageUrl { get; set; }

        [DisplayName("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

    }
}
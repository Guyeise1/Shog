using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Gosh.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }

        public DateTime? DateCreated { get; set; }

        public string Header { get; set; }

        public string Summary { get; set; }

        public string Content { get; set; }

        public string HomeImageUrl { get; set; }

        [DisplayName("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

    }
}
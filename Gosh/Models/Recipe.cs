using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Gosh.Models
{
    public class Recipe
    {
        public long RecipeId { get; set; }

        [DisplayName("Creation Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateCreated { get; set; }

        [DisplayName("Recipe Name")]
        public string Header { get; set; }

        public string Summary { get; set; }

        [DisplayName("Recipe Ingredients & Directions ")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [DisplayName("Image")]
        public string HomeImageUrl { get; set; }

        [DisplayName("Category")]
        [ForeignKey("Category")]
        public long CategoryId { get; set; }

        public virtual Category Category { get; set; }

    }
}
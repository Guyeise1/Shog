using System.ComponentModel;

namespace Gosh.Models
{
    public class Category
    {
        public long ID { get; set; }

        [DisplayName("Category name")]
        public string CategoryName { get; set; }

        [DisplayName("Image")]
        public string ImagePath { get; set; }

        [DisplayName("Represnting City")]
        public string RepresetingCity { get; set; }
        
    }
}
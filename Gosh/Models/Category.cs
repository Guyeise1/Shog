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
        
        [DisplayName("Represeting Area")]
        public string RepresetingArea { get; set; }

        [DisplayName("Weather href")]
        public string WeatherHref { get; set; }
    }
}
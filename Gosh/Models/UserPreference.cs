using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Gosh.Models
{
    public class UserPreference
    {
        public long ID { get; set; }

        [ForeignKey("User")]
        public long UserID { get; set; }

        [DisplayName("User")]
        public User User { get; set; }

        [ForeignKey("Category")]
        public long CategoryID { get; set; }

        [DisplayName("Chosen Category")]
        public Category Category { get; set; }

        [DisplayName("Date")]
        public DateTime Date { get; set; }
    }
}
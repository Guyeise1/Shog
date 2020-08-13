using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Gosh.Models
{
    public class User
    {
        public long ID { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [MinLength(5)]
        [StringLength(50)]
        [Index("IX_Username", IsUnique = true)]

        public string Username { get; set; }

        [DataType(DataType.Password)]
        [NotMapped]
        public string Password { get; set; }


        [NotMapped]
        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [DisplayName("First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]

        [DisplayName("Last name")]
        public string LastName { get; set; }

        // TODO: Add this field after implamenting Address class
        //public Address Address { get; set; }

        [DataType(DataType.EmailAddress)]
        [StringLength(50)]
        [Index("IX_Email", IsUnique = true)]

        public string Mail { get; set; }

        [DataType(DataType.CreditCard)]
        [DisplayName("Credit Card")]
        public string CreditCard { get; set; }


        [DataType(DataType.PhoneNumber)]
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }


        
    }
}
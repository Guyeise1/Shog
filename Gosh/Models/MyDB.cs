using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Gosh.Models
{
    public class MyDB: DbContext
    {

        //public System.Data.Entity.DbSet<Gosh.Models.Customer> Customers { get; set; }
       // public DbSet<Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<Gosh.Models.Category> Categories { get; set; }


        public System.Data.Entity.DbSet<Gosh.Models.User> Users { get; set; }
        public System.Data.Entity.DbSet<Gosh.Models.Password> Passwords{ get; set; }

        public System.Data.Entity.DbSet<Gosh.Models.Recipe> Recipes { get; set; }
    }
}
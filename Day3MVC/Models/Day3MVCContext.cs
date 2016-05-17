using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Day3MVC.Models
{
    public class Day3MVCContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Day3MVCContext() : base("name=Day3MVCContext")
        {
        }

        public System.Data.Entity.DbSet<Day3MVC.Models.Cities> Cities { get; set; }

        public System.Data.Entity.DbSet<Day3MVC.Models.Customers> Customers { get; set; }

        public System.Data.Entity.DbSet<Day3MVC.Models.PropertyModels> PropertyModels { get; set; }

        public System.Data.Entity.DbSet<Day3MVC.Models.Sales> Sales { get; set; }

        public System.Data.Entity.DbSet<Day3MVC.Models.States> States { get; set; }

        public System.Data.Entity.DbSet<Day3MVC.Models.Zips> Zips { get; set; }

        public System.Data.Entity.DbSet<Day3MVC.Models.ZipToCities> ZipToCities { get; set; }
    }
}

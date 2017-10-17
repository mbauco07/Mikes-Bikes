using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Mikes_Bikes.Models
{
    public class Mikes_BikesContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Mikes_BikesContext() : base("name=Mikes_BikesContext")
        {
        }

        public System.Data.Entity.DbSet<Mikes_Bikes.Models.Bike> Bikes { get; set; }

        public System.Data.Entity.DbSet<Mikes_Bikes.Models.Cart> Carts { get; set; }

        public System.Data.Entity.DbSet<Mikes_Bikes.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<Mikes_Bikes.Models.Detail> Details { get; set; }

        public System.Data.Entity.DbSet<Mikes_Bikes.Models.Order> Orders { get; set; }

        public System.Data.Entity.DbSet<Mikes_Bikes.Models.Rating> Ratings { get; set; }
    }
}

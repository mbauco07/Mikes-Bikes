using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Mikes_Bikes.Models;

namespace Mikes_Bikes
{
    public class DAL
    {
        public class Mikes_BikesContext : DbContext
        {
        }


        public DbSet<Bike> Bikes { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Rating> Ratings { get; set; }






    }
}
          
    


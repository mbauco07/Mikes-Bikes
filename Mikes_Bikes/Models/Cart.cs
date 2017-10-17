using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Mikes_Bikes.Models
{
    public class Cart
    {
        public int CartID { get; set; }
        public int CustomerID { get; set; }
        public string BikeID { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Bike Bike { get; set; }

    }

}
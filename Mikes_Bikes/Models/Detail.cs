using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MikesBikes.Models
{
    public class Detail
    {
        public int OrderID { get; set; }
        public string BikeID { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mikes_Bikes.Models
{
    public class Rating
    {
        public int RatingID { get; set; }
        public int CustomerID { get; set; }
        public string BikeID { get; set; }
        public int Rate { get; set; }
        public string Review { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Bike Bike { get; set; }


    }

    
}
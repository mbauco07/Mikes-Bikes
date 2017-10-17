using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MikesBikes.Models
{
    public class Rating
    {
        public int RateID { get; set; }
        public int CustID { get; set; }
        public string BikeID { get; set; }
        public int Rate { get; set; }
        public string Review { get; set; }
    }
}
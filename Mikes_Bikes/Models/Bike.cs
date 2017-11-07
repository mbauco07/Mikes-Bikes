using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Mikes_Bikes.Models
{
    public class Bike
    {
        public string BikeID { get; set; }
        public string BikeName { get; set; }
        public string BikeColor { get; set; }
        public string BikeMfctr { get; set; }
        public string BikeType { get; set; }
        public Double BikePrice { get; set; }
        public string BikeDescEN { get; set; }
        public string BikeDescFR { get; set; }
        public double BikeSaleAmt { get; set; }
        public bool BikeDisplayed { get; set; }
        public int BikeStock { get; set; }
        public string BikeImage { get; set; }
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Mikes_Bikes.Models
{
    public class Bike
    {
        [Required]
        public string BikeID { get; set; }
        [Required]
        public string BikeName { get; set; }
        [Required]
        public string BikeColor { get; set; }
        [Required]
        public string BikeMfctr { get; set; }
        [Required]
        public string BikeType { get; set; }
        public Double BikePrice { get; set; }
        [Required]
        public string BikeDescEN { get; set; }
        [Required]
        public string BikeDescFR { get; set; }
        public double BikeSaleAmt { get; set; }
        [Required]
        public bool BikeDisplayed { get; set; }
        [Required]
        public int BikeStock { get; set; }
        public string BikeImage { get; set; }
  

    }

}

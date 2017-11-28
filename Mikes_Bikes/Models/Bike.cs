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
        [Display(Name ="Bike Name")]
        public string BikeName { get; set; }
        [Display(Name = "Bike Color")]
        public string BikeColor { get; set; }
        [Display(Name = "Manufacturer")]
        public string BikeMfctr { get; set; }
        [Display(Name = "Type")]
<<<<<<< HEAD
=======
        // Merge Conflict Issue
        /*[Required]
        public string BikeName { get; set; }
        [Required]
        public string BikeColor { get; set; }
        [Required]
        public string BikeMfctr { get; set; }*/
>>>>>>> 7ccb88144463e48792802b9118be85b986f7fda7
        [Required]
        public string BikeType { get; set; }
        [Display(Name = "Price")]
        public Double BikePrice { get; set; }
        [Display(Name = "Description")]
        public string BikeDescEN { get; set; }
        [Display(Name = "Déscription")]
        public string BikeDescFR { get; set; }
        public double BikeSaleAmt { get; set; }
<<<<<<< HEAD
=======
        // Merge Conflict Issue
        /*[Required]
        public string BikeDescEN { get; set; }
        [Required]
        public string BikeDescFR { get; set; }
        public double BikeSaleAmt { get; set; }*/
>>>>>>> 7ccb88144463e48792802b9118be85b986f7fda7
        [Required]
        public bool BikeDisplayed { get; set; }
        [Required]
        public int BikeStock { get; set; }
        public string BikeImage { get; set; }
  

    }

}

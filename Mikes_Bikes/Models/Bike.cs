using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;
namespace Mikes_Bikes.Models
{
    public class Bike
    {
        [Required]
        public string BikeID { get; set; }
<<<<<<< HEAD
        [Display(Name ="Bike Name")]
        public string BikeName { get; set; }
        [Display(Name = "Bike Color")]
        public string BikeColor { get; set; }
        [Display(Name = "Manufacturer")]
        public string BikeMfctr { get; set; }
        [Display(Name = "Type")]
=======
        [Required]
        public string BikeName { get; set; }
        [Required]
        public string BikeColor { get; set; }
        [Required]
        public string BikeMfctr { get; set; }
        [Required]
>>>>>>> 00a0ea6e61fd129a5191ebbb326497fdddbf6258
        public string BikeType { get; set; }
        [Display(Name = "Price")]
        public Double BikePrice { get; set; }
<<<<<<< HEAD
        [Display(Name = "Description")]
        public string BikeDescEN { get; set; }
        [Display(Name = "Déscription")]
        public string BikeDescFR { get; set; }
        public double BikeSaleAmt { get; set; }
        
=======
        [Required]
        public string BikeDescEN { get; set; }
        [Required]
        public string BikeDescFR { get; set; }
        public double BikeSaleAmt { get; set; }
        [Required]
>>>>>>> 00a0ea6e61fd129a5191ebbb326497fdddbf6258
        public bool BikeDisplayed { get; set; }
        [Required]
        public int BikeStock { get; set; }
        public string BikeImage { get; set; }
  

    }

}

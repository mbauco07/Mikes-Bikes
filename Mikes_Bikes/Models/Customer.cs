using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mikes_Bikes.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "First Name Required")]
        public string CustFName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Last Name Required")]
        public string CustLName { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email Required")]
        public string CustEmail { get; set; }

        [DisplayName("Phone Number")]
        [Required(ErrorMessage = "Phone Number Required")]
        public string CustPhone { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Password Required")]
        public string CustPwd { get; set; }
    }

}
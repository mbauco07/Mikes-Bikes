using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MikesBikes.Models
{
    public class Customer
    {
        public int CustID { get; set; }
        public string CustFName { get; set; }
        public string CustLName { get; set; }
        public string CustEmail { get; set; }
        public string CustPhone { get; set; }
        public string CustPwd { get; set; }
    }

}
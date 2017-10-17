using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MikesBikes.Models
{
    public class Order
    {
        public string OrderID { get; set; }
        public int CustID { get; set; }
        public int DetailID { get; set; }
        public DateTime OrderDate { get; set; }
        public double OrderPrice { get; set; }
    }

}
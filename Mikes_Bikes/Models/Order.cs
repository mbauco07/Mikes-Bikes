using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Mikes_Bikes.Models
{
    public class Order
    {
        public string OrderID { get; set; }
        public int CustomerID { get; set; }
        public int DetailID { get; set; }
        public DateTime OrderDate { get; set; }
        public double OrderPrice { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<Detail> Details { get; set; }


    }

}
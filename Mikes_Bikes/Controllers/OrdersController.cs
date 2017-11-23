using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mikes_Bikes.Models;

namespace Mikes_Bikes.Controllers
{
    public class OrdersController : Controller
    {
        private Mikes_BikesContext db = new Mikes_BikesContext();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.Customer);
            return View(orders.ToList());
        }
        //DARIO FIX THIS
        // GET: Orders/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var orderDetails = db.Details;
            List<String> bikeList = new List<String>();
            foreach(Detail detail in orderDetails)
            {
                if(detail.OrderID.ToString()==id)
                {
                    string bikeName = db.Bikes.Find(detail.BikeID).BikeName;
                    bikeList.Add(bikeName);
                }
            }
            if (orderDetails == null)
            {
                return HttpNotFound();
            }
            return View(bikeList);
        }
    }
}

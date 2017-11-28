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

        [HttpPost]
        // [ValidateAntiForgeryToken]
        public ActionResult AddOrder()
        {
            int custId = 1;
            Order newOrder = new Order();

                ViewBag.completed = "review was sent";
                newOrder.CustomerID = custId;
                newOrder.DetailID = 1; //this is beeing used for testing ONLY
                newOrder.OrderDate = new DateTime();
                newOrder.OrderPrice = @ViewBag.Total;
                if (ModelState.IsValid)
                {
                    db.Orders.Add(newOrder);
                    db.SaveChanges();
                    return PartialView("_ReviewForm");
                }
            return PartialView("_ReviewForm");
                
        }

        // GET: Orders
        public ActionResult Index(string id)
        {
            id = "1";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var orderDetails = db.Orders;
            List<String> Order = new List<String>();
            List<Order> list = new List<Models.Order>();
            foreach(Order detail in orderDetails)
            {
                if(detail.OrderID.ToString()==id)
                {
                    list.Add(detail);
                }
            }
            if (orderDetails == null)
            {
                return HttpNotFound();
            }
            return View(list);
        }
        //DARIO FIX THIS
        // GET: Orders/Details/5
        public ActionResult Details(string id)
        {
            id = "1";
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

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
    public class BikesController : Controller
    {
        private Mikes_BikesContext db = new Mikes_BikesContext();
        
        // GET: Bikes
        public ActionResult Index(string bikeId,string sortColumn,string searchBike="")
        {
            //list of all bikes
            var bikes = from bike in db.Bikes select bike;
            //Get all bike categories
            var categoryList = new List<string>();
            var categoryQuery = from b in db.Bikes select b.BikeType;
            categoryList.AddRange(categoryQuery.Distinct());
            ViewBag.bike = new SelectList(categoryList);

            // Sorting by field
            sortColumn = String.IsNullOrEmpty(sortColumn) ? "" : sortColumn.ToLower();
            ViewBag.nameSort = sortColumn == "bikename" ? "bikename_desc" : "bikename";
            ViewBag.colourSort = sortColumn == "bikecolour" ? "bikecolour_desc" : "bikecolour";
            ViewBag.mtfSort = sortColumn == "bikemtf" ? "bikemtf_desc" : "bikemtf";
            ViewBag.typeSort = sortColumn == "biketype" ? "biketype_desc" : "biketype";
            ViewBag.priceSort = sortColumn == "bikeprice" ? "bikeprice_desc" : "bikeprice";
            ViewBag.saleSort = sortColumn == "bikesale" ? "bikesale_desc" : "bikesale";
            ViewBag.displaySort = sortColumn == "bikedisplay" ? "bikedisplay_desc" : "bikedisplay";
            ViewBag.stockSort = sortColumn == "bikestock" ? "bikestock_desc" : "bikestock";

            //Sort asc or desc, based on column clicked and state
            switch (sortColumn)
            {
                case "bikename":
                    bikes = bikes.OrderBy(bike => bike.BikeName);
                    break;
                case "bikename_desc":
                    bikes = bikes.OrderByDescending(bike => bike.BikeName);
                    break;
                case "bikecolour":
                    bikes = bikes.OrderBy(bike => bike.BikeColor);
                    break;
                case "bikecolour_desc":
                    bikes = bikes.OrderByDescending(bike => bike.BikeColor);
                    break;
                case "biketype":
                    bikes = bikes.OrderBy(bike => bike.BikeType);
                    break;
                case "biketype_desc":
                    bikes = bikes.OrderByDescending(bike => bike.BikeType);
                    break;
                case "bikemtf":
                    bikes = bikes.OrderBy(bike => bike.BikeMfctr);
                    break;
                case "bikemtf_desc":
                    bikes = bikes.OrderByDescending(bike => bike.BikeMfctr);
                    break;
                case "bikeprice":
                    bikes = bikes.OrderBy(bike => bike.BikePrice);
                    break;
                case "bikeprice_desc":
                    bikes = bikes.OrderByDescending(bike => bike.BikePrice);
                    break;
                case "bikesale":
                    bikes = bikes.OrderBy(bike => bike.BikeSaleAmt);
                    break;
                case "bikesale_desc":
                    bikes = bikes.OrderByDescending(bike => bike.BikeSaleAmt);
                    break;
                case "bikedisplay":
                    bikes = bikes.OrderBy(bike => bike.BikeDisplayed);
                    break;
                case "bikedisplay_desc":
                    bikes = bikes.OrderByDescending(bike => bike.BikeDisplayed);
                    break;
                case "bikestock":
                    bikes = bikes.OrderBy(bike => bike.BikeStock);
                    break;
                case "bikestock_desc":
                    bikes = bikes.OrderByDescending(bike => bike.BikeStock);
                    break;
                default:
                    bikes = bikes.OrderBy(bike => bike.BikeName);
                    break;
            }


            // Selecting correct bikeId.
            if (!String.IsNullOrEmpty(bikeId))
                bikes = bikes.Where(bike => bike.BikeID  == bikeId);
            // Searching
            //Make sure search string is atleast 3 chars long
            if(searchBike.Length<=3)
                return View(bikes.ToList());
            bikes = String.IsNullOrEmpty(searchBike) ? bikes : bikes.Where(bike => bike.BikeName.Contains(searchBike));
            return View(bikes.ToList());
        }

        // GET: Bikes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bike bike = db.Bikes.Find(id);
            if (bike == null)
            {
                return HttpNotFound();
            }
            return View(bike);
        }

        // GET: Bikes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bikes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BikeID,BikeName,BikeColor,BikeMfctr,BikeType,BikePrice,BikeDescEN,BikeDescFR,BikeSaleAmt,BikeDisplayed,BikeStock")] Bike bike)
        {
            if (ModelState.IsValid)
            {
                db.Bikes.Add(bike);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bike);
        }

        // GET: Bikes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bike bike = db.Bikes.Find(id);
            if (bike == null)
            {
                return HttpNotFound();
            }
            return View(bike);
        }

        // POST: Bikes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BikeID,BikeName,BikeColor,BikeMfctr,BikeType,BikePrice,BikeDescEN,BikeDescFR,BikeSaleAmt,BikeDisplayed,BikeStock")] Bike bike)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bike).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bike);
        }

        // GET: Bikes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bike bike = db.Bikes.Find(id);
            if (bike == null)
            {
                return HttpNotFound();
            }
            return View(bike);
        }

        // POST: Bikes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Bike bike = db.Bikes.Find(id);
            db.Bikes.Remove(bike);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddToCart(string id)
        {
            CartsController cartsCon = new CartsController();
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bike bike = db.Bikes.Find(id);
            if (bike == null)
            {
                return HttpNotFound();
            }
            // This will have to be retrieved from the session variable.
            int custId=1;
            // This will have to be retrieved from the textbox on the ItemView page. 
            int qty=5;
            double price=bike.BikePrice;
            // TEMP
            var cartQuery = from c in db.Carts
                            where c.BikeID == id
                            select c.CartID;

            
            //Cart tmp = db.Carts.Find();
            // Already in the cart
            /*if (tmp.BikeID == id)
            {
                Cart cart = new Cart { CustomerID = custId, BikeID = id, Quantity = qty+2, Price = price };
                cartsCon.Edit(tmp.CartID);
            }
            else
            {*/
                Cart cart = new Cart { CustomerID = custId, BikeID = id, Quantity = qty, Price = price };
                cartsCon.Create(cart);
            //}

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

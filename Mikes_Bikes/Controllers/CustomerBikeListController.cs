﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mikes_Bikes.Models;
using PagedList;

namespace Mikes_Bikes.Controllers
{
    public class CustomerBikeListController : Controller
    {
        private Mikes_BikesContext db = new Mikes_BikesContext();


        // GET: Bikes
        public ActionResult Index(int? page, string bikeCat, string sortColumn, string searchBike = "")
        {
            //list of all bikes
            var bikes = from bike in db.Bikes select bike;
            //Get all bike categories
            var categoryList = new List<string>();
            var categoryQuery = from b in db.Bikes select b.BikeType;
            categoryList.AddRange(categoryQuery.Distinct());
            ViewBag.bikeCat = new SelectList(categoryList);

            // Sorting by field
            sortColumn = String.IsNullOrEmpty(sortColumn) ? "" : sortColumn.ToLower();
            ViewBag.idSort = sortColumn == "bikeid" ? "bikeid_desc" : "bikeid";
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
                case "bikeid":
                    bikes = bikes.OrderBy(bike => bike.BikeID);
                    break;
                case "bikeid_desc":
                    bikes = bikes.OrderByDescending(bike => bike.BikeID);
                    break;
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

            int pageSize = 2;//change this number to change how many bikes are shown per page
            int pageNumber = page ?? 1;
            // Selecting correct bikeId.
            if (!String.IsNullOrEmpty(bikeCat))
                bikes = bikes.Where(bike => bike.BikeType == bikeCat);
            // Searching
            //Make sure search string is atleast 3 chars long
            if (searchBike.Length <= 3)
                return View(bikes.ToPagedList(pageNumber, pageSize));
            bikes = String.IsNullOrEmpty(searchBike) ? bikes : bikes.Where(bike => bike.BikeName.Contains(searchBike));
            //Pagation

            return View(bikes.ToPagedList(pageNumber, pageSize));
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
            int custId;
            string bikeId;
            int qty;
            double price;
            Customer customer;


            Cart cart = new Cart();
            cartsCon.Create(cart);


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

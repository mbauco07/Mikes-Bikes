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
    public class CategoryController : Controller
    {
        private Mikes_BikesContext db = new Mikes_BikesContext();

        // GET: Category
        public ActionResult Index(string sortColumn)
        {
            //Sorting
            ViewBag.typeSort = sortColumn == "biketype" ? "biketype_desc" : "biketype";

            var categories = from bike in db.Bikes select bike;

            switch (sortColumn)
            {
                case "biketype":
                    categories = categories.OrderBy(bike => bike.BikeType);
                    break;
                case "biketype_desc":
                    categories = categories.OrderByDescending(bike => bike.BikeType);
                    break;
            }

            return View(categories.ToList());
        }

        public ActionResult BikesInCategory(string theType)
        {
            var bikes = from bike in db.Bikes where bike.BikeType == theType select bike;

            return View(bikes.ToList());
        }

        // GET: Category/Details/5
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

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BikeID,BikeName,BikeColor,BikeMfctr,BikeType,BikePrice,BikeDescEN,BikeDescFR,BikeSaleAmt,BikeDisplayed,BikeStock,BikeImage")] Bike bike)
        {
            if (ModelState.IsValid)
            {
                db.Bikes.Add(bike);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bike);
        }

        // GET: Category/Edit/5
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

        // POST: Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BikeID,BikeName,BikeColor,BikeMfctr,BikeType,BikePrice,BikeDescEN,BikeDescFR,BikeSaleAmt,BikeDisplayed,BikeStock,BikeImage")] Bike bike)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bike).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bike);
        }

        // GET: Category/Delete/5
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

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Bike bike = db.Bikes.Find(id);
            db.Bikes.Remove(bike);
            db.SaveChanges();
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

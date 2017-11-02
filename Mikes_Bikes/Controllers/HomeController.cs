using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mikes_Bikes.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Mikes Bikes";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Connect With Us Beyond the Store!";

            return View();
        }

        public ActionResult Careers()
        {
            ViewBag.Message = "Your careers page.";

            return View();
        }

        public ActionResult ReturnPolicy()
        {
            return View();
        }

        public ActionResult BikeSafety()
        {
            return View();
        }
    }
}
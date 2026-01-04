using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OdevD1.Models;

namespace OdevD1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult SliderTest()
        {
            ChadDBEntities db = new ChadDBEntities();
            var liste = db.ResimlerSliders.ToList();
            return Content(liste.Count.ToString());
        }

        public ActionResult Index()
        {
            ChadDBEntities db = new ChadDBEntities();
            var sliderList = db.ResimlerSliders.ToList();
            return View(sliderList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
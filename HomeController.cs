using WebDevProject.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebDevProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<DataPoint> dataPoints = new List<DataPoint>{
                new DataPoint(10, 22),
                new DataPoint(20, 36),
                new DataPoint(30, 42),
                new DataPoint(40, 51),
                new DataPoint(50, 46),
            };

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult CareTaker()
        {
            ViewBag.Message = "Your CareTaker page.";

            return View();
        }

        [Authorize(Roles = "Organization,Admin")]
        public ActionResult Organization()
        {
            ViewBag.Message = "Roles.";

            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Admin()
        {
            {
                List<DataPoint> dataPoints = new List<DataPoint>{
                new DataPoint(10, 22),
                new DataPoint(20, 36),
                new DataPoint(30, 42),
                new DataPoint(40, 51),
                new DataPoint(50, 46),
            };

                ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
                ViewBag.Message = "Roles.";

                return View();
            }


        }
    }
}
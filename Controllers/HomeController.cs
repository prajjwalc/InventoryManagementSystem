using InventoryManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagment.Controllers
{       
    public class HomeController : Controller
    {

        ValidEntities db = new ValidEntities();

        public ActionResult Index()
        {


            return View();
        }


       
        [HttpPost]
        public ActionResult Index
            (tab tb)

        {
            var tab = db.tabs.Where(x => x.Username == tb.Username && x.Password == tb.Password).Count();
            if (tab > 0)
            {
                return RedirectToAction("DashBoard");

            }
            else
            {
                return View();

            }

        }

        public ActionResult DashBoard()
        {
            return View();
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
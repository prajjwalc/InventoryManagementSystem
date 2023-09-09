

using InventoryManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagment.Controllers
{
    public class ProductController : Controller
    {
        Inventory_managementEntities db = new Inventory_managementEntities();
        // GET: Product

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DisplayProduct()
        { List < Product > list = db.Products.OrderByDescending(x => x.Id).ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult UpdateProduct(int Id)
        {      Product pr=db.Products.Where(x => x.Id == Id).SingleOrDefault();
            return View(pr);
        }

        [HttpPost]
        public ActionResult CreateProduct(Product pro)
        {
            db.Products.Add(pro);
            db.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }
        [HttpPost]
        public ActionResult UpdateProduct(int Id,Product pro)
        {
            Product pr = db.Products.Where(x => x.Id == Id).SingleOrDefault();
              pr.Product_name = pro.Product_name;
              pr.Product_qnty = pro.Product_qnty;
              db.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }
        [HttpGet]
        public ActionResult Productdetail(int Id)
        {
            Product pro = db.Products.Where(x => x.Id == Id).SingleOrDefault();
            return View(pro);
        }

        [HttpGet]
        public ActionResult DeleteProduct(int Id)
        {
            Product pro = db.Products.Where(x => x.Id == Id).SingleOrDefault();
            return View(pro);
        }
        [HttpPost]
        public ActionResult DeleteProduct(int Id,Product pro)
        {
           Product p=  db.Products.Where(x => x.Id == Id).SingleOrDefault();
            db.Products.Remove(p);
            db.SaveChanges();
            return RedirectToAction("DisplayProduct");
        }
    }
}
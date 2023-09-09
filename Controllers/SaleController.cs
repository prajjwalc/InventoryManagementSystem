using InventoryManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagment.Controllers
{
    public class SaleController : Controller
    {
        // GET: Sale
        Inventory_managementEntities db = new Inventory_managementEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DisplaySale()
        {
            List<Sale> list = db.Sales.OrderByDescending(x => x.Id).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult SaleProduct()
        {
            List<string> list = db.Products.Select(x => x.Product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View();
        }
        [HttpPost]
        public ActionResult SaleProduct(Sale pur)
        {
            db.Sales.Add(pur);
            db.SaveChanges();

            return RedirectToAction("DisplaySale");
        }



        [HttpGet]
        public ActionResult Details(int Id)
        {
            Sale s = db.Sales.Where(x => x.Id == Id).SingleOrDefault();

            return View(s);
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            Sale p = db.Sales.Where(x => x.Id == Id).SingleOrDefault();

            return View(p);
        }
        [HttpPost]
        public ActionResult Delete(int Id, Sale per)
        {
            Sale po = db.Sales.Where(x => x.Id == Id).SingleOrDefault();
            db.Sales.Remove(po);
            db.SaveChanges();

            return RedirectToAction("DisplaySale");
        }

        [HttpGet]

        public ActionResult Edit(int Id)
        {
            Sale s = db.Sales.Where(x => x.Id == Id).SingleOrDefault();
            List<string> list = db.Products.Select(x => x.Product_name).ToList();
            ViewBag.ProductName = new SelectList(list);


            return View(s);
        }
        [HttpPost]

        public ActionResult Edit(int Id, Sale sale)
        {
            Sale s = db.Sales.Where(x => x.Id == Id).SingleOrDefault();
            s.Sale_date = sale.Sale_date;
            s.Sale_prod = sale.Sale_prod;
            s.Sale_qnty = sale.Sale_qnty;
            db.SaveChanges();

            return RedirectToAction("DisplaySale");
        }
    }
}
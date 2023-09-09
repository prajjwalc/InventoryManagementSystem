﻿using InventoryManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagment.Controllers
{
    public class PurchaseController : Controller
    {
        // GET: Purchase
        Inventory_managementEntities db = new Inventory_managementEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DisplayPurchase()
        {
            List<Purchase> list = db.Purchases.OrderByDescending(x => x.Id).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult PurchaseProduct()
        {
            List<string> list = db.Products.Select(x => x.Product_name).ToList();
            ViewBag.ProductName=new SelectList(list);
            return View();
        }
        [HttpPost]
        public ActionResult PurchaseProduct(Purchase pur)
        {
            db.Purchases.Add(pur);
            db.SaveChanges();

            return RedirectToAction("DisplayPurchase");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            Purchase p = db.Purchases.Where(x => x.Id == Id).SingleOrDefault();
            List<string> list = db.Products.Select(x => x.Product_name).ToList();
            ViewBag.ProductName = new SelectList(list);

            return View(p);
        }

        [HttpPost]

        public ActionResult Edit(int Id,Purchase pur)
        {
            Purchase p = db.Purchases.Where(x => x.Id == Id).SingleOrDefault();
            p.Purchase_date= pur.Purchase_date;
            p.Purchase_prod= pur.Purchase_prod;
            p.Purchase_qnty = pur.Purchase_qnty;

            return RedirectToAction("DisplayPurchase");
        }

        [HttpGet]
        public ActionResult Details(int Id)
        {
          Purchase p = db.Purchases.Where(x => x.Id == Id).SingleOrDefault();

            return View(p);
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            Purchase p = db.Purchases.Where(x => x.Id == Id).SingleOrDefault();
             
            return View(p);
        }
        [HttpPost]
        public ActionResult Delete(int Id,Purchase per)
        {
            Purchase p = db.Purchases.Where(x => x.Id == Id).SingleOrDefault();
            db.Purchases.Remove(p);
            db.SaveChanges();

            return RedirectToAction("DisplayPurchase");
        }


    }
    
    








}

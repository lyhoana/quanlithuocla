using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLTL_V2.Models;

namespace QLTL_V2.Controllers
{ 
    public class BuyPriceController : Controller
    {
        private DBEntities db = new DBEntities();

        //
        // GET: /BuyPrice/

        public ViewResult Index()
        {
            var buyprices = db.BuyPrices.Include(b => b.Product).Include(b => b.CustomerType).Include(b => b.ProductUnit);
            return View(buyprices.ToList());
        }

        //
        // GET: /BuyPrice/Details/5

        public ViewResult Details(int id)
        {
            BuyPrice buyprice = db.BuyPrices.Find(id);
            return View(buyprice);
        }

        //
        // GET: /BuyPrice/Create

        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Code");
            ViewBag.CustomerTypeId = new SelectList(db.CustomerTypes, "CustomerTypeId", "Name");
            ViewBag.ProductUnitId = new SelectList(db.ProductUnits, "ProductUnitId", "Name");
            return View();
        } 

        //
        // POST: /BuyPrice/Create

        [HttpPost]
        public ActionResult Create(BuyPrice buyprice)
        {
            if (ModelState.IsValid)
            {
                db.BuyPrices.Add(buyprice);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Code", buyprice.ProductId);
            ViewBag.CustomerTypeId = new SelectList(db.CustomerTypes, "CustomerTypeId", "Name", buyprice.CustomerTypeId);
            ViewBag.ProductUnitId = new SelectList(db.ProductUnits, "ProductUnitId", "Name", buyprice.ProductUnitId);
            return View(buyprice);
        }
        
        //
        // GET: /BuyPrice/Edit/5
 
        public ActionResult Edit(int id)
        {
            BuyPrice buyprice = db.BuyPrices.Find(id);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Code", buyprice.ProductId);
            ViewBag.CustomerTypeId = new SelectList(db.CustomerTypes, "CustomerTypeId", "Name", buyprice.CustomerTypeId);
            ViewBag.ProductUnitId = new SelectList(db.ProductUnits, "ProductUnitId", "Name", buyprice.ProductUnitId);
            return View(buyprice);
        }

        //
        // POST: /BuyPrice/Edit/5

        [HttpPost]
        public ActionResult Edit(BuyPrice buyprice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buyprice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Code", buyprice.ProductId);
            ViewBag.CustomerTypeId = new SelectList(db.CustomerTypes, "CustomerTypeId", "Name", buyprice.CustomerTypeId);
            ViewBag.ProductUnitId = new SelectList(db.ProductUnits, "ProductUnitId", "Name", buyprice.ProductUnitId);
            return View(buyprice);
        }

        //
        // GET: /BuyPrice/Delete/5
 
        public ActionResult Delete(int id)
        {
            BuyPrice buyprice = db.BuyPrices.Find(id);
            return View(buyprice);
        }

        //
        // POST: /BuyPrice/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            BuyPrice buyprice = db.BuyPrices.Find(id);
            db.BuyPrices.Remove(buyprice);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
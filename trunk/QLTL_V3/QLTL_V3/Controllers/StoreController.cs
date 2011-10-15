using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLTL_V3.Models;

namespace QLTL_V3.Controllers
{ 
    public class StoreController : Controller
    {
        private DBEntities db = new DBEntities();

        //
        // GET: /Store/

        public ViewResult Index()
        {
            var stores = db.Stores.Include(s => s.Product).Include(s => s.ProductUnit);
            return View(stores.ToList());
        }

        //
        // GET: /Store/Details/5

        public ViewResult Details(int id)
        {
            Store store = db.Stores.Find(id);
            return View(store);
        }

        //
        // GET: /Store/Create

        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Code");
            ViewBag.ProductUnitId = new SelectList(db.ProductUnits, "ProductUnitId", "Name");
            return View();
        } 

        //
        // POST: /Store/Create

        [HttpPost]
        public ActionResult Create(Store store)
        {
            if (ModelState.IsValid)
            {
                db.Stores.Add(store);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Code", store.ProductId);
            ViewBag.ProductUnitId = new SelectList(db.ProductUnits, "ProductUnitId", "Name", store.ProductUnitId);
            return View(store);
        }
        
        //
        // GET: /Store/Edit/5
 
        public ActionResult Edit(int id)
        {
            Store store = db.Stores.Find(id);
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Code", store.ProductId);
            ViewBag.ProductUnitId = new SelectList(db.ProductUnits, "ProductUnitId", "Name", store.ProductUnitId);
            return View(store);
        }

        //
        // POST: /Store/Edit/5

        [HttpPost]
        public ActionResult Edit(Store store)
        {
            if (ModelState.IsValid)
            {
                db.Entry(store).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Code", store.ProductId);
            ViewBag.ProductUnitId = new SelectList(db.ProductUnits, "ProductUnitId", "Name", store.ProductUnitId);
            return View(store);
        }

        //
        // GET: /Store/Delete/5
 
        public ActionResult Delete(int id)
        {
            Store store = db.Stores.Find(id);
            return View(store);
        }

        //
        // POST: /Store/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Store store = db.Stores.Find(id);
            db.Stores.Remove(store);
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
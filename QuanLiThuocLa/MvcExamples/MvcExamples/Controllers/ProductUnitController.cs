using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcExamples.Models;

namespace MvcExamples.Controllers
{ 
    public class ProductUnitController : Controller
    {
        private DBEntities db = new DBEntities();

        //
        // GET: /ProductUnit/

        public ViewResult Index()
        {
            return View(db.ProductUnits.ToList());
        }

        //
        // GET: /ProductUnit/Details/5

        public ViewResult Details(int id)
        {
            ProductUnit productunit = db.ProductUnits.Find(id);
            return View(productunit);
        }

        //
        // GET: /ProductUnit/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /ProductUnit/Create

        [HttpPost]
        public ActionResult Create(ProductUnit productunit)
        {
            if (ModelState.IsValid)
            {
                db.ProductUnits.Add(productunit);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(productunit);
        }
        
        //
        // GET: /ProductUnit/Edit/5
 
        public ActionResult Edit(int id)
        {
            ProductUnit productunit = db.ProductUnits.Find(id);
            return View(productunit);
        }

        //
        // POST: /ProductUnit/Edit/5

        [HttpPost]
        public ActionResult Edit(ProductUnit productunit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productunit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productunit);
        }

        //
        // GET: /ProductUnit/Delete/5
 
        public ActionResult Delete(int id)
        {
            ProductUnit productunit = db.ProductUnits.Find(id);
            return View(productunit);
        }

        //
        // POST: /ProductUnit/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            ProductUnit productunit = db.ProductUnits.Find(id);
            db.ProductUnits.Remove(productunit);
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
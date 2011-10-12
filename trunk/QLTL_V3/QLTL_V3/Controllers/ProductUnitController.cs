using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLTL_V3.Models;
using QLTL_V3.ViewModel;

namespace QLTL_V3.Controllers
{ 
    public class ProductUnitController : Controller
    {
        private DBEntities db = new DBEntities();

        //
        // GET: /ProductUnit/

        [HttpPost]
        public JsonResult SearchProductUnit(string term)
        {
            List<ProductUnit> productUnits = (from u in db.ProductUnits
                                      where u.Name.ToUpper().Contains(term.ToUpper())
                                      orderby u.Name // optional but it'll look nicer
                                      select u).ToList();
            List<ProductUnitModelView> pro = new List<ProductUnitModelView>();
            foreach (var c in productUnits)
            {
                pro.Add(new ProductUnitModelView { Name = c.Name, ProductUnitId = c.ProductUnitId });
            }
            return Json(pro);
        }

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
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
    public class CustomerTypeController : Controller
    {
        private DBEntities db = new DBEntities();

        //
        // GET: /CustomerType/

        public ViewResult Index()
        {
           
            return View(db.CustomerTypes.ToList());
        }

        //
        // GET: /CustomerType/Details/5

        public ViewResult Details(int id)
        {
            CustomerType customertype = db.CustomerTypes.Find(id);
            return View(customertype);
        }

        //
        // GET: /CustomerType/Create

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Report()
        {
            return View();
        } 

        //
        // POST: /CustomerType/Create

        [HttpPost]
        public ActionResult Create(CustomerType customertype)
        {
            if (ModelState.IsValid)
            {
                db.CustomerTypes.Add(customertype);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(customertype);
        }
        
        //
        // GET: /CustomerType/Edit/5
 
        public ActionResult Edit(int id)
        {
            CustomerType customertype = db.CustomerTypes.Find(id);
            return View(customertype);
        }

        //
        // POST: /CustomerType/Edit/5

        [HttpPost]
        public ActionResult Edit(CustomerType customertype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customertype).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
                Session["OrderId"] = 4;
                return RedirectToAction("Report");
            }
            return View(customertype);
        }

        //
        // GET: /CustomerType/Delete/5
 
        public ActionResult Delete(int id)
        {
            CustomerType customertype = db.CustomerTypes.Find(id);
            return View(customertype);
        }

        //
        // POST: /CustomerType/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            CustomerType customertype = db.CustomerTypes.Find(id);
            db.CustomerTypes.Remove(customertype);
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
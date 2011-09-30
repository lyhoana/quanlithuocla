using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcExamples.Models;
using MvcExamples.ViewModel;
namespace MvcExamples.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Order/
        private DBEntities db = new DBEntities();

        public ActionResult Index()
        {
            var customers = db.Orders;
            return View(customers.ToList());
        }

        //
        // GET: /Order/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Order/Create

        public ActionResult Create()
        {
            ViewBag.CustomerTypeId = new SelectList(db.CustomerTypes, "CustomerTypeId", "Name");
            ViewBag.CustomerId = new SelectList(db.Customers,"CustomerId", "Name");
            return View();
        } 

        //
        // POST: /Order/Create

       

        [HttpPost]
        public ActionResult Create(Order order )
        {

            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name");
                ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name");
                ViewBag.ProductUnitId = new SelectList(db.ProductUnits, "ProductUnitId","Name");
                return View(order);
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name");
            ViewBag.CustomerTypeId = new SelectList(db.CustomerTypes, "CustomerTypeId", "Name");
            return View(order);
            

        }

        [HttpPost]
        public ActionResult Govalidate(FormCollection collection,Order order)
        {
           try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Order/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Order/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Order/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Order/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

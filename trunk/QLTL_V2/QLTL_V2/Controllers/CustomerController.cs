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
    public class CustomerController : Controller
    {
        private DBEntities db = new DBEntities();

        //
        // GET: /Customer/

        public ViewResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name desc" : "";

            var customers = from s in db.Customers.Include(o => o.CustomerType)
                            select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                customers = customers.Where(s => s.Name.ToUpper().Contains(searchString.ToUpper()));

            }
            switch (sortOrder)
            {
                case "Name desc":
                    customers = customers.OrderByDescending(s => s.Name);
                    break;

                default:
                    customers = customers.OrderBy(s => s.Name);
                    break;
            }

            return View(customers.ToList());
        }

        //
        // GET: /Customer/Details/5

        public ViewResult Details(int id)
        {
            Customer customer = db.Customers.Find(id);
            return View(customer);
        }

        //
        // GET: /Customer/Create

        public ActionResult Create()
        {
            ViewBag.CustomerTypeId = new SelectList(db.CustomerTypes, "CustomerTypeId", "Name");
            return View();
        } 

        //
        // POST: /Customer/Create

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.CustomerTypeId = new SelectList(db.CustomerTypes, "CustomerTypeId", "Name", customer.CustomerTypeId);
            return View(customer);
        }
        
        //
        // GET: /Customer/Edit/5
 
        public ActionResult Edit(int id)
        {
            Customer customer = db.Customers.Find(id);
            ViewBag.CustomerTypeId = new SelectList(db.CustomerTypes, "CustomerTypeId", "Name", customer.CustomerTypeId);
            return View(customer);
        }

        //
        // POST: /Customer/Edit/5

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerTypeId = new SelectList(db.CustomerTypes, "CustomerTypeId", "Name", customer.CustomerTypeId);
            return View(customer);
        }

        //
        // GET: /Customer/Delete/5
 
        public ActionResult Delete(int id)
        {
            Customer customer = db.Customers.Find(id);
            return View(customer);
        }

        //
        // POST: /Customer/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public string UpdateForm(string textBox1)
        {
            if (textBox1 != "Enter text")
            {
                return "You entered: \"" + textBox1.ToString() + "\" at " +
                    DateTime.Now.ToLongTimeString();
            }

            return String.Empty;
        }
    }
}
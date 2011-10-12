using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLTL_V3.Models;
namespace QLTL_V3.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Order/
        private DBEntities db = new DBEntities();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            Order order = new Order();
            db.Orders.Add(order);
            db.SaveChanges();
            return RedirectToAction("New", new { orderId = order.OrderId });
        }

        [HttpGet]
        public ActionResult New(int orderId)
        {
            Order order = db.Orders.Find(orderId);           
            return View(order);
        }

    }
}

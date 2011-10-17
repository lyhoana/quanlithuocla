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
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "Name");
            ViewBag.ProductUnitId = new SelectList(db.ProductUnits, "ProductUnitId", "Name");
            return View(order);
        }

        public PartialViewResult AddItem(int ProductId, int ProductUnitId, string Price, int Amount,  int OrderId)
        {
            decimal price = decimal.Parse(Price.Replace('$',' ').Replace(',',' ').Trim());
            OrderDetail orderDetail = new OrderDetail { OrderId = OrderId, ProductId = ProductId, ProductUnitId = ProductUnitId, Amount = Amount, Price = price };
            db.OrderDetails.Add(orderDetail);
            db.SaveChanges();           
            var l = db.OrderDetails.Include("Product").Include("ProductUnit").Where(o => o.OrderId == OrderId);
            return PartialView("_OrderDetailPartial", l.ToList());

        }

    }
}

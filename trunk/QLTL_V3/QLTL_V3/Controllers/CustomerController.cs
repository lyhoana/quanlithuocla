using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLTL_V3.Models;
using QLTL_V3.ViewModel;

namespace QLTL_V3.Controllers
{
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/
        private DBEntities db = new DBEntities();
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public JsonResult SearchCustomer(string term)
        {
            List<Customer> customers = (from u in db.Customers.Include("CustomerType")
                                        where u.Name.ToUpper().Contains(term.ToUpper())
                                        orderby u.Name // optional but it'll look nicer
                                        select u).ToList();
            List<CustomerModelView> cus = new List<CustomerModelView>();
            foreach (var c in customers)
            {
                cus.Add(new CustomerModelView { Name = c.Name, CustomerId = c.CustomerId, Address = c.Address ,PhoneNo = c.PhoneNo, CustomerTypeId = c.CustomerTypeId , CustomerTypeName = c.CustomerType.Name });
            }
            return Json(cus);
        }
    }
}

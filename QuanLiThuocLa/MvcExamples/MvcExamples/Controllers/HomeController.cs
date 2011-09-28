using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcExamples.Models;

namespace MvcExamples.Controllers
{
    public class HomeController : Controller
    {
        private DBEntities db = new DBEntities();
        public ActionResult Index()
        {
            
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            var menus = db.Menus.ToList();
            return View(menus);
           
        }
       
        public ActionResult About()
        {
            return View();
        }
    }
}

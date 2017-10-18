using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FWG.Controllers
{
    public class CompanyController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            ViewBag.Title = "Employees";
            
            return View();
        }

        public ActionResult Employees()
        {
            ViewBag.Title = "Employees";
            return View();
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FWG.Controllers
{
    public class ClientsController : Controller
    {
        // GET: Clients
        public ActionResult Clients()
        {
            return View();
        }
    }
}
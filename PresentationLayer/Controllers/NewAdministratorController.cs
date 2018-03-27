using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    public class NewAdministratorController : Controller
    {
        // GET: NewAdministrator
        public ActionResult Index()
        {
            return View("newAdministrator");
        }
    }
}
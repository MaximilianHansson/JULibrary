using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceLayer.Models;
using ServiceLayer.Managers;

namespace PresentationLayer.Controllers
{
    public class SignUpController : Controller
    {
        // GET: SignUp
        public ActionResult Index()
        {
            return View("SignUp");
        }

        [HttpPost]
        public ActionResult Index(string userName, string password)
        {
            AdministratorManager adminManager = new AdministratorManager();
            adminManager.createAdministrator(userName, password);
            return View("SignUp");
        }
    }
}
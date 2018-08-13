using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceLayer.Models;
using ServiceLayer.Managers;

namespace PresentationLayer.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }

        public RedirectResult Logout(string pathBack)
        {
            Session.Remove("User");
            return Redirect(pathBack);
        }

        [HttpPost]
        public ActionResult Index(string userName, string password)
        {
            AdministratorManager adminManager = new AdministratorManager();
            var admin = adminManager.login(userName, password);
            Session["User"] = admin.username;
            return View("Login", admin);
        }
    }
}
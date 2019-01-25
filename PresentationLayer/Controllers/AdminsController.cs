using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceLayer.Managers;
using ServiceLayer.Models;

namespace PresentationLayer.Controllers
{
    public class AdminsController : Controller
    {
        // GET: Admins
        public ActionResult Index()
        {
            if (Session["User"] == null)
            { return View("~/Views/Shared/Unauthorized.cshtml"); }

            AdministratorManager DBadmin = new AdministratorManager();
			List<Administrator> admins = new List<Administrator>();
			admins = DBadmin.getAllAdmins();
			//List<Administrator> admins = DBadmin.getAllAdmins();


			return View("Admins", admins);
        }
    }
}
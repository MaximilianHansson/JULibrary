using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceLayer.Models;
using ServiceLayer.Managers;
using ServiceLayer.Validation;

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
			//validation
			SignUpValidator validator = new SignUpValidator();
			var validResult = validator.validate(userName, password);

			if(validResult.Count == 0)
			{
				//Creating a new admin
				AdministratorManager adminManager = new AdministratorManager();
				adminManager.createAdministrator(userName, password);
				ViewBag.Success = 1;
			}
			else
			{
				ViewBag.Validation = validResult;
			}

			
            return View("SignUp");
        }
    }
}
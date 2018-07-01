using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceLayer.Managers;
using ServiceLayer.Models;

namespace PresentationLayer.Controllers
{
	
	public class CreateAuthorController : Controller
    {
		// GET: CreateAuthor
		public ActionResult Index() //Not sure if this is right
        {
			var firstName = Request.Form["firstName"];
			var lastName = Request.Form["lastName"];
			var birthYear = Request.Form["birthYear"];
			if (firstName != "" && lastName != "" && birthYear != "")
			{
				AuthorManager newAuthor = new AuthorManager();
				newAuthor.createAuthor(firstName, lastName, birthYear);
			}

			return View("CreateAuthor");
        }
    }
}
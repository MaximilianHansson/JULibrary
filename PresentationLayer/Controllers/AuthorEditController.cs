using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceLayer.Managers;
using ServiceLayer.Models;

namespace PresentationLayer.Controllers
{
	public class AuthorEditController : Controller
	{
		// GET: AuthorEdit
		public ActionResult Index(int Aid)
		{
			AuthorManager DBauthor = new AuthorManager();
			Author author = new Author();

			author = DBauthor.getAuthor(Aid);

			var firstName = Request.Form["firstName"];
			var lastName = Request.Form["lastName"];
			var birthYear = Request.Form["birthYear"];

			//if (author.FirstName != firstName || author.LastName != lastName || author.BirthYear != birthYear)
			//{
			//	AuthorManager editAuthor = new AuthorManager();
			//	editAuthor.editAuthor(firstName, lastName, birthYear, Aid);
			//}

			return View("AuthorEdit", author);
		}

		[HttpPost]
		public ActionResult Index()
		{
			var firstName = Request.Form["firstName"];
			var lastName = Request.Form["lastName"];
			var birthYear = Request.Form["birthYear"];
			//Got to acces Aid
			var AidStr = Request.QueryString["Aid"];
			var Aid = Convert.ToInt32(AidStr);

			AuthorManager author = new AuthorManager();
			author.editAuthor(firstName, lastName, birthYear, Aid);

			//This is the only thing that doesen't work atm
			return View("Edited");
		}
	}
}
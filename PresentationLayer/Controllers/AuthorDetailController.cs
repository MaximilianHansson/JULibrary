using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceLayer.Managers;
using ServiceLayer.Models;

namespace PresentationLayer.Controllers
{
    public class AuthorDetailController : Controller
    {
        // GET: AuthorDetail
        public ActionResult Index(int Aid)
        {
			AuthorManager DBauthor = new AuthorManager();
			Author author = new Author();

			author = DBauthor.getAuthor(Aid);

			if(author.BirthYear == null) { author.BirthYear = "Unknown"; }

			return View("AuthorDetail", author);
        }

		public ActionResult Delete(int Aid)
		{
            if (Session["User"] == null)
            { return View("~/Views/Shared/Unauthorized.cshtml"); }

            AuthorManager DBauthor = new AuthorManager();
			DBauthor.deleteAuthor(Aid);
			return View("Deleted");
		}
    }
}
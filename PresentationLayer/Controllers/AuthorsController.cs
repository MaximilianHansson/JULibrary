using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceLayer.Managers;
using PagedList;

namespace PresentationLayer.Controllers
{
    public class AuthorsController : Controller
    {
        // GET: Authors
        public ActionResult Index(string searchString, string currentFilter, int? page)
        {
			if (searchString != null)
			{
				page = 1;
			}
			else
			{
				searchString = currentFilter;
			}

			ViewBag.CurrentFilter = searchString;

			int pageSize = 15;
			int pageNumber = (page ?? 1);

			if (!String.IsNullOrEmpty(searchString))
			{
				AuthorManager incomingAuthors = new AuthorManager();
				var authorList = incomingAuthors.getAuthors(searchString);

				return View("Authors", authorList.ToPagedList(pageNumber, pageSize));
			}
			else
			{
				AuthorManager incomingAuthors = new AuthorManager();
				var authorList = incomingAuthors.getAllAuthors();

				return View("Authors", authorList.ToPagedList(pageNumber, pageSize));
			}
        }
    }
}
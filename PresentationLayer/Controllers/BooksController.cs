using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceLayer.Managers;
using PagedList;

namespace PresentationLayer.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        public ActionResult Index(string searchString, string currentFilter, int? page)
        {

			if(searchString != null)
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
                BookManager incomingBooks = new BookManager();
                var bookList = incomingBooks.getBooks(searchString);

				return View("Books", bookList.ToPagedList(pageNumber, pageSize));
            }
            else
            {
				BookManager incomingBooks = new BookManager();
				var bookList = incomingBooks.getAllBooks(); 

                return View("Books", bookList.ToPagedList(pageNumber, pageSize));
			}
        }
	}
}
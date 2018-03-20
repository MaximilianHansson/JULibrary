using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceLayer.Managers;
using ServiceLayer.Models;
using PagedList;

namespace PresentationLayer.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        public ActionResult Index(string searchString, string currentFilter, int? page, string searchTerm)
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
                List<Book> bookList = new List<Book>();

                if (searchTerm == "isbn")
                {
                    bookList = incomingBooks.getBooksByIsbn(searchString);
                }
                else if (searchTerm == "classification")
                {
                    bookList = incomingBooks.getBooksByClassi(searchString);
                }
                else
                {
                    bookList = incomingBooks.getBooks(searchString);
                }

                return View("Books", bookList.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                BookManager incomingBooks = new BookManager();
                List<Book> bookList = new List<Book>();
                
                bookList = incomingBooks.getAllBooks();

                return View("Books", bookList.ToPagedList(pageNumber, pageSize));
            }
        }
	}
}
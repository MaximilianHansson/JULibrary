using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceLayer.Managers;

namespace PresentationLayer.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        public ActionResult Index(string searchString)
        {
			BookManager incomingBooks = new BookManager();
			var bookList = incomingBooks.getBooks(searchString);

			//ViewData["bookList"] = bookList;

            return View("Books", bookList);
        }

		//public object Index(int page = 1)
		//{
		//	//var products = MyProductDataSource.FindAllProducts(); //returns IQueryable<Product> representing an unknown number of products. a thousand maybe?


		//	//var onePageOfProducts = products.ToPagedList(pageNumber, 25); // will only contain 25 products max because of the pageSize

		//	//ViewBag.OnePageOfProducts = onePageOfProducts;
		//	return View();
		//}
	}
}
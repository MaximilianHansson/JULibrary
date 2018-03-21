using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceLayer.Managers;
using ServiceLayer.Models;

namespace PresentationLayer.Controllers
{
    public class BookDetailController : Controller
    {
        // GET: BookDetail
        public ActionResult Index(string isbn)
        {
            BookManager DBbook = new BookManager();
            Book book = new Book();

            book = DBbook.getBook(isbn);

            //if(book.PublicationYear == null){book.PublicationYear = "unknown";}
            if(book.pages == null) { book.pages = 0; }
            if(book.publicationinfo == null) { book.publicationinfo = "unknown"; }
            
            return View("BookDetail", book);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceLayer.Managers;
using ServiceLayer.Models;

namespace PresentationLayer.Controllers
{
    public class BookEditController : Controller
    {
        // GET: BookEdit
        public ActionResult Index(string isbn)
        {
            BookManager DBbook = new BookManager();
            Book book = new Book();

            book = DBbook.getBook(isbn);

            if (book.Title == null) { book.Title = "unknown"; }
            if (book.PublicationYear == null) { book.PublicationYear = "unknown"; }
            if (book.pages == null) { book.pages = 0; }
            if (book.publicationinfo == null) { book.publicationinfo = "unknown"; }

            return View("bookEdit", book);
        }

        [HttpPost]
        public ActionResult Index()
        {
            BookManager BookEdit = new BookManager();
            BookEdit.editBook(Request["Title"], Request["newISBN"], Request["pages"], Request["PublicationInfo"], Request.Form["authors"].Split(',').ToList(), Request["oldISBN"]);

            return View("Edited");
        }
    }
}
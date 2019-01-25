using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceLayer.Managers;
using ServiceLayer.Models;
using ServiceLayer.Validation;

namespace PresentationLayer.Controllers
{
    public class BookEditController : Controller
    {
        // GET: BookEdit
        public ActionResult Index(string isbn)
        {
            if (Session["User"] == null)
            { return View("~/Views/Shared/Unauthorized.cshtml"); }

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
            if (Session["User"] == null)
            { return View("~/Views/Shared/Unauthorized.cshtml"); }

            BookValidatior bookValidator = new BookValidatior();
            var smartIsbn = (Request["newISBN"] == Request["oldISBN"])? "0" : Request["newISBN"];
            var validateResult = bookValidator.validate(Request["Title"], smartIsbn, Request["pages"], Request["PublicationInfo"], Request.Form["authors"].Split(',').ToList());
            if(validateResult.Count == 0)
            {
                BookManager BookEdit = new BookManager();
                BookEdit.editBook(Request["Title"], Request["newISBN"], Request["pages"], Request["PublicationInfo"], Request.Form["authors"].Split(',').ToList(), Request["oldISBN"]);

                return View("Edited");
            }
            else
            {
                ViewBag.Validation = validateResult;

                Index(Request["oldISBN"]);

                return View("bookEdit");
            }
            
        }
    }
}
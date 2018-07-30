using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceLayer.Managers;

namespace PresentationLayer.Controllers
{
    public class CreateBookController : Controller
    {
        // GET: CreateBook
        public ActionResult Index()
        {
            if (Request.Form["Title"] != null && Request.Form["authors"] != null)
            {
                var title = Request.Form["Title"];
                var ISBN = Request.Form["ISBN"];
                var pages = Request.Form["pages"];
                var publicationInfo = Request.Form["PublicationInfo"];
                var signID = Request.Form["signId"];
                var authors = Request.Form["authors"].Split(',').ToList();


                BookManager newBook = new BookManager();
                newBook.createBook(title, ISBN, pages, publicationInfo, signID, authors);
            }
            


            return View("CreateBook");
        }
    }
}
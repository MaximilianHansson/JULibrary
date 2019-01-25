using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceLayer.Managers;
using ServiceLayer.Validation;

namespace PresentationLayer.Controllers
{
    public class CreateBookController : Controller
    {
        // GET: CreateBook
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["User"] == null)
            { return View("~/Views/Shared/Unauthorized.cshtml"); }
            return View("CreateBook");
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult IndexPost()
        {
            if (Session["User"] == null)
            { return View("~/Views/Shared/Unauthorized.cshtml"); }

            var title = Request.Form["Title"];
            var ISBN = Request.Form["ISBN"];
            var pages = Request.Form["pages"];
            var publicationInfo = Request.Form["PublicationInfo"];
            var signID = Request.Form["signId"];
            var authors = Request.Form["authors"].Split(',').ToList();

            BookValidatior bookValidator = new BookValidatior();
            var validateResult = bookValidator.validate(title, ISBN, pages, publicationInfo, authors);
            if (validateResult.Count == 0){
                BookManager newBook = new BookManager();
                newBook.createBook(title, ISBN, pages, publicationInfo, signID, authors);
                return View("CreateBook");
            }
            else
            {
                ViewBag.Validation = validateResult;
                return View("CreateBook");
            }
            
        }
    }
}
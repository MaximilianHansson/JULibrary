﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayer.Controllers
{
    public class AdministratorsController : Controller
    {
        // GET: Administrators
        public ActionResult Index()
        {
            return View("Administrators");
        }
    }
}
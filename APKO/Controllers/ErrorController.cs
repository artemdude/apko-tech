﻿using System.Web.Mvc;

namespace APKO.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Error/

        public ActionResult Index()
        {
            return View("Error");
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult NotFound(string aspxerrorpath)
        {
            ViewData["error_path"] = aspxerrorpath;

            return View();
        }

    }
}

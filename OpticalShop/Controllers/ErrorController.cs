using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpticalShop.Controllers
{
    public class ErrorController : Controller
    {
        // GET: /Error/

        public ActionResult Index(int statusCode, Exception exception)
        {
            Response.StatusCode = statusCode;
            return View(exception);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NoTrace.WebApi.Web.Controllers
{
    public class HomeController : NoTraceControllerBase
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}
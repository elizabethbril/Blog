using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult Posts()
        {
            ViewBag.Title = "Adding Post";

            return View();
        }

        public ActionResult Pages()
        {
            ViewBag.Title = "Adding Pages";

            return View();
        }

        public ActionResult Users()
        {
            ViewBag.Title = "Registering User";

            return View();
        }

    }
}

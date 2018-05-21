using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FaculdadeXPTO.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Faculdade XPTO.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contato da página";

            return View();
        }
    }
}
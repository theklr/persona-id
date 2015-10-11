using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Persona.Controllers
{
    public class DocController : Controller
    {
        // GET: Doc
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Portfolio()
        {
            return View();
        }


        public ActionResult Verfication()
        {
            return View();
        }


        public ActionResult Confirmation()
        {
            return View();
        }
    }
}
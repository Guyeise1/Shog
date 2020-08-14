using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gosh.Controllers
{
    public class InspirationController : Controller
    {
        // GET: Inspiration
        public ActionResult Index()
        {
            return View();
        }

        // GET: Inspiration/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }



    }
}

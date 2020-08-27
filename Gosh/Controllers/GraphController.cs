using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gosh.Models;

namespace Gosh.Controllers
{
    class QueryResult
    {
        public string CategoryName { get; set; }
        public int NumOfRecipes { get; set; }
        public int year { get; set; }
        public int recipes { get; set; }
    }
    public class GraphController : Controller
    {
        private MyDB db = new MyDB();
        public bool IsAdmin()
        {
            return Session["Username"] != null && Session["Username"].ToString() == "ADMIN";
        }

        // GET: Graph
        public ActionResult Index()
        {
            if (!IsAdmin())
            {
                return RedirectToAction("Forbidden");
            }
            return View(db.Categories.ToList());
        }

        public ActionResult Forbidden()
        {
            Response.StatusCode = (int)HttpStatusCode.Forbidden;
            Response.StatusDescription = "You are not allowed to enter this page";
            return View();
        }

        public ActionResult GetAllCategories()
        {
            var res = db.Categories.Select(c => new
            {
                CategoryName = c.CategoryName,
                NumOfRecipes = db.Recipes.Count(r => r.CategoryId == c.ID)
            }).ToList();

            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetRecipesByYears()
        {
            var res = db.Recipes.GroupBy(r => r.DateCreated.Value.Year).Select(s => new
            {
                year = s.Key,
                recipes = s.Count()
            });
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}
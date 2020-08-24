﻿using System;
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
    }
    public class GraphController : Controller
    {
        private MyDB db = new MyDB();

        // GET: Graph
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        public ActionResult GetAllCategories()
        {
            //var getRecipes = db.Recipes
            //var query = db.Categories.Select(cat => new { name = cat.CategoryName, count = cat.ID });
            //return Json(query, JsonRequestBehavior.AllowGet);

            var query = db.Database.SqlQuery<QueryResult>(
                "select CategoryName, (select count(RecipeId) from Recipes r where r.CategoryId = c.ID) as NumOfRecipes from Categories c order by c.CategoryName").ToList();

            return Json(query, JsonRequestBehavior.AllowGet);
        }
    }
}
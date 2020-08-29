using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gosh.Controllers.Statistics;
using Gosh.Models;



namespace Gosh.Controllers
{
    public class RecipesController : Controller
    {
        private MyDB db = new MyDB();

        //// GET: Recipes
        //public ActionResult Index()
        //{
            
        //    return View(db.Recipes.ToList());
        //}
        // string[] because this is how View sends the id...
        public ActionResult ByCategoryID(string[] CategoryID)
        {
            int ID = int.Parse(((string[])CategoryID)[0]);
            return View("Index",db.Recipes.Where(r => r.CategoryId == ID).ToList());
        }
       
        // GET: Recipes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }

            // User must be logged in to see recipies
            if (Session["Userid"] == null)
            {
                return RedirectToAction("Forbidden", "User");
            }

            new RecipeLearning().SavePreference((long)Session["Userid"], (int)id);

            return View(recipe);
        }

        // GET: Recipes/Create
        public ActionResult Create()
        {
            // User must be logged in to see recipies
            if (Session["Userid"] == null)
            {
                return RedirectToAction("Forbidden", "User");
            }
            ViewBag.Categories = new SelectList(db.Categories, "ID", "CategoryName");
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecipeId,Header,Summary,Content,HomeImageUrl,CategoryId")] Recipe recipe, HttpPostedFileBase Imagefile)
        {

            string path = Path.Combine(Server.MapPath("~/Images"),
                                       Path.GetFileName(Imagefile.FileName));
            Imagefile.SaveAs(path);
            recipe.HomeImageUrl = Imagefile.FileName;
            if (ModelState.IsValid)
            {
                recipe.DateCreated = DateTime.Now;
                db.Recipes.Add(recipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recipe);
        }

        // GET: Recipes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecipeId,DateCreated,Header,Summary,Content,HomeImageUrl,CategoryId")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recipe);
        }

        // GET: Recipes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recipe recipe = db.Recipes.Find(id);
            db.Recipes.Remove(recipe);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Search recipes by filters
        /// </summary>
        /// <param name="Header">
        /// If our recipe header contains the given parameter. REGEXP - *name*
        /// </param>
        /// <param name="C">
        /// If our recipe is in the given catergory C.
        /// </param>
        /// <param name="created_after">
        /// If the recipe created after the given date.
        /// </param>
        /// <returns>
        /// List of all recipes fits to all conditions.
        /// </returns>
        public ActionResult Index(string Header, int? categoryId, DateTime? created_after)
        {
            ViewBag.categoryId = new SelectList(db.Categories, "ID", "CategoryName");
            return View(db.Recipes.Where(r => (Header == null || r.Header.Contains(Header) ) &&
                (categoryId == null || r.CategoryId == categoryId) &&
                (created_after == null || r.DateCreated >= created_after)).ToList());
        }
    }
}

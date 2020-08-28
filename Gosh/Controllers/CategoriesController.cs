using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Gosh.Controllers.Statistics;
using Gosh.Models;

namespace Gosh.Controllers
{
    public class CategoriesController : Controller
    {
        private MyDB db = new MyDB();
        public bool IsAdmin()
        {
            return Session["Username"] != null && Session["Username"].ToString() == "ADMIN";
        }
        // GET: User





    public ActionResult RecommendedForYou()
        {
            if(Session["Userid"] == null)
            {
                // return new UserController().Forbidden();
                return RedirectToAction("Forbidden", "User");
            }

            return View("Index", new RecipeLearning().RecommendedForYou((long)Session["Userid"], 3));
        }

        // GET: Categories/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            ViewData["Recipes"] = await db.Recipes
              .Where(x => x.CategoryId == id).ToListAsync();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            if (!IsAdmin())
            {
                return RedirectToAction("Forbidden", "User");
            }
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CategoryName,ImagePath,RepresetingArea,WeatherHref")] Category category, HttpPostedFileBase file)
        {
            if (!IsAdmin())
            {
                return RedirectToAction("Forbidden", "User");
            }

            if (file != null)
            {
                string path = Path.Combine(Server.MapPath("~/Images"),
                           Path.GetFileName(file.FileName));
                file.SaveAs(path);
                category.ImagePath = file.FileName;
            } 

            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(long? id)
        {
            if (!IsAdmin())
            {
                return RedirectToAction("Forbidden","User");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CategoryName,ImagePath,RepresetingArea,WeatherHref")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(long? id)
        {
            if (!IsAdmin())
            {
                return RedirectToAction("Forbidden", "User");
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
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
        /// Search category by the given filters
        /// </summary>
        /// <param name="name">
        /// If our category name contains the given parameter. REGEXP - *name*
        /// </param>
        /// <param name="minimumRecipeCount">
        /// If our category has more than the given value recipes.
        /// </param>
        /// <param name="area">
        /// If the category in the given area (drop down list).
        /// </param>
        /// <returns>
        /// List of categories match the filetr.
        /// </returns>
        public ActionResult Index(string name, int? minimumRecipeCount, string area)
        {
      
            ViewBag.area = new SelectList(db.Categories, "RepresetingArea", "RepresetingArea");

            return View(db.Categories.Where(c => (c.CategoryName.Contains(name) || name == null) &&
            (area == null || c.RepresetingArea.Contains(area)) && 
            (minimumRecipeCount == null || db.Recipes.Where(r => r.CategoryId == c.ID).Count() >= minimumRecipeCount)).ToList());
        }
    }
}   
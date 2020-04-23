using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EnvisionAGreenLife.Models;

namespace EnvisionAGreenLife.Controllers
{
    public class Food_recipesController : Controller
    {
        private LeftoverRecipesEntities db = new LeftoverRecipesEntities();

        // GET: Food_recipes
        public ActionResult Index()
        {
            return View(db.Food_recipes.ToList());
        }

        // GET: Food_recipes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food_recipes food_recipes = db.Food_recipes.Find(id);
            if (food_recipes == null)
            {
                return HttpNotFound();
            }
            return View(food_recipes);
        }

        // GET: Food_recipes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Food_recipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,title,ingredients,instructions,preparation_time,difficulty_level,category_breakfast,category_lunch,category_dinner,category_dessert")] Food_recipes food_recipes)
        {
            if (ModelState.IsValid)
            {
                db.Food_recipes.Add(food_recipes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(food_recipes);
        }

        // GET: Food_recipes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food_recipes food_recipes = db.Food_recipes.Find(id);
            if (food_recipes == null)
            {
                return HttpNotFound();
            }
            return View(food_recipes);
        }

        // POST: Food_recipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,title,ingredients,instructions,preparation_time,difficulty_level,category_breakfast,category_lunch,category_dinner,category_dessert")] Food_recipes food_recipes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(food_recipes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(food_recipes);
        }

        // GET: Food_recipes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food_recipes food_recipes = db.Food_recipes.Find(id);
            if (food_recipes == null)
            {
                return HttpNotFound();
            }
            return View(food_recipes);
        }

        // POST: Food_recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Food_recipes food_recipes = db.Food_recipes.Find(id);
            db.Food_recipes.Remove(food_recipes);
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
    }
}

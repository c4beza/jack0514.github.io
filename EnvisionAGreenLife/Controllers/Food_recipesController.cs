using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EnvisionAGreenLife.Models;
using EnvisionAGreenLife.ViewModel;
using MvcBreadCrumbs;
using PagedList;

namespace EnvisionAGreenLife.Controllers
{
    public class Food_recipesController : Controller
    {
        private LeftoverRecipesEntities db = new LeftoverRecipesEntities();

        // GET: Food_recipes
        [BreadCrumb(Clear = true, Label = "Breakfast Recipes")]
        [HttpGet]
        public ActionResult breakfast_recipes(int? page, string searchString, string currentFilter)
        {
            var results = from x in db.Food_recipes
                          select x;
            int pagesize = 9, pageindex = 1;
            breakfastList temp = new breakfastList();
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                results = results.Where(s => s.ingredients.Contains(searchString));
            }

            else
            {
                results = results.Where(x => x.category_breakfast == true);
            }

            pageindex = page.HasValue ? Convert.ToInt32(page) : 1;
            var list = results.ToList();
            temp.Breakfasts = list.ToPagedList(pageindex, pagesize);
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("LeftOverRecipe", "Home"), "Left Over Recpies");
            return View(temp);
        }

        [BreadCrumb(Clear = true, Label = "Lunch Recipes")]
        [HttpGet]
        public ActionResult lunch_recipes(int? page, string searchString, string currentFilter)
        {
            var results = from x in db.Food_recipes
                          select x;
            int pagesize = 9, pageindex = 1;
            lunchList temp = new lunchList();
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                results = results.Where(s => s.ingredients.Contains(searchString));
            }

            else
            {
                results = results.Where(x => x.category_lunch == true);
            }

            pageindex = page.HasValue ? Convert.ToInt32(page) : 1;
            var list = results.ToList();
            temp.Lunch = list.ToPagedList(pageindex, pagesize);
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("LeftOverRecipe", "Home"), "Left Over Recpies");
            return View(temp);
        }

        [BreadCrumb(Clear = true, Label = "Dinner Recipes")]
        [HttpGet]
        public ActionResult dinner_recipes(int? page, string searchString, string currentFilter)
        {
            var results = from x in db.Food_recipes
                          select x;
            int pagesize = 9, pageindex = 1;
            dinnerList temp = new dinnerList();
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                results = results.Where(s => s.ingredients.Contains(searchString));
            }

            else
            {
                results = results.Where(x => x.category_dinner == true);
            }

            pageindex = page.HasValue ? Convert.ToInt32(page) : 1;
            var list = results.ToList();
            temp.Dinner = list.ToPagedList(pageindex, pagesize);
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("LeftOverRecipe", "Home"), "Left Over Recpies");
            return View(temp);
        }

        [BreadCrumb(Clear = true, Label = "Dinner Recipes")]
        [HttpGet]
        public ActionResult dessert_recipes(int? page, string searchString, string currentFilter)
        {
            var results = from x in db.Food_recipes
                          select x;
            int pagesize = 9, pageindex = 1;
            dessertList temp = new dessertList();
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                results = results.Where(s => s.ingredients.Contains(searchString));
            }

            else
            {
                results = results.Where(x => x.category_dessert == true);
            }

            pageindex = page.HasValue ? Convert.ToInt32(page) : 1;
            var list = results.ToList();
            temp.Dessert = list.ToPagedList(pageindex, pagesize);
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("LeftOverRecipe", "Home"), "Left Over Recpies");
            return View(temp);
        }

        // GET: Food_recipes/Details/5
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food_recipes food_Recipes = db.Food_recipes.Find(id);
            if (food_Recipes == null)
            {
                return HttpNotFound();
            }
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("ReuceFoodWaste", "Home"), "Reduce Food Waste");
            BreadCrumb.Add(Url.Action("LeftoverRecipe", "Home"), "Leftover Recipes");
            BreadCrumb.Add("", food_Recipes.title);
            return View(food_Recipes);
        }




    }
}

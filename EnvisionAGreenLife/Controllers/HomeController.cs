using PagedList;
using EnvisionAGreenLife.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBreadCrumbs;

namespace EnvisionAGreenLife.Controllers
{
    [BreadCrumb]
    public class HomeController : Controller
    {
        AppliancesEntities db = new AppliancesEntities();
        LeftoverRecipesEntities recipesEntities = new LeftoverRecipesEntities();

        //logic leading to the home page from the homepage
        [HttpGet]
        public ActionResult Index()
        {
            BreadCrumb.Clear();
            return View();
        }

        //logic leading to the quiz page from the home page.
        [HttpGet]
        public ActionResult Quiz()
        {
            ViewBag.Message = "How much do you know about saving money and energy?";
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add("", "Household Assessment");
            return View();
        }

        //logic leading to the about page from the home page.
        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Message = "Description";
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add("", "Learn More");
            return View();
        }

        //logic leading to the reduce food page from the home page.
        [HttpGet]
        public ActionResult ReduceFoodWaste()
        {
            ViewBag.Message = "Reduce waste";
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add("", "Reduce Waste");
            return View();
        }

        //logic leading to the leftover recipe page selected from the food waste dropdown list while on the the home page.
        [HttpGet]
        public ActionResult LeftoverRecipe()
        {
            ViewBag.Message = "LeftoverRecipe";
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("ReduceFoodWaste", "Home"), "Reduce Waste");
            BreadCrumb.Add("", "Left-Over Food Recipes");
            List<SelectListItem> Difficulty_level = new List<SelectListItem>();
            Difficulty_level.Add(new SelectListItem() { Text = "All", Value = null });
            Difficulty_level.Add(new SelectListItem() { Text = "Easy", Value = "easy" });
            Difficulty_level.Add(new SelectListItem() { Text = "Average", Value = "average" });
            Difficulty_level.Add(new SelectListItem() { Text = "Challenging", Value = "Challenging" });
            this.ViewBag.Difficulty = new SelectList(Difficulty_level, "Value", "Text");
            return View();
        }

        //logic leading to the  appliance page page selected from the  save energy dropdown list while on the the home page.
        [HttpGet]
        public ActionResult AppliancesType()
        {
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add("", "Save Energy");
            return View();
        }

        [HttpPost]
        public ActionResult AppliancesType(string searchString)
        {
            String temp = searchString.ToLower();
            if ("air conditioners".Contains(temp))
            {
                return RedirectToAction("Index", "air_conditioner");
            }
            else
                if ("clothes dryers".Contains(temp))
            {
                return RedirectToAction("Index", "clothes_dryer");
            }
            else
                if ("clothes washers".Contains(temp))
            {
                return RedirectToAction("Index", "clothes_washer");
            }
            else
                if ("dishwashers".Contains(temp))
            {
                return RedirectToAction("Index", "dishwashers");
            }
            else
                if ("monitors".Contains(temp))
            {
                return RedirectToAction("Index", "monitors");
            }
            else
                if ("refrigerators".Contains(temp))
            {
                return RedirectToAction("Index", "refrigerators");
            }
            else
                if ("televisions".Contains(temp))
            {
                return RedirectToAction("Index", "televisions");
            }
            else
            {
                ViewData["foundOrNot"] = "NO";
                return View();
            }
        }

        [HttpGet]
        public ActionResult Comingsoon()
        {
            BreadCrumb.Clear();
            return View();
        }

        //logic leading to the composting page selected from the  reuse dropdown list while on the the home page.
        [HttpGet]
        public ActionResult Composting()
        {
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add("", "Composting");
            return View();
        }

        //logic leading to different page related to different types of compsot categories.
        [HttpGet]
        public ActionResult apartment()
        {
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("Composting", "Home"), "Composting");
            BreadCrumb.Add("", "Apartment");
            return View();
        }

        [HttpGet]
        public ActionResult townhouse()
        {
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("Composting", "Home"), "Composting");
            BreadCrumb.Add("", "Townhouse");
            return View();
        }

        [HttpGet]
        public ActionResult suburban_household()
        {
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("Composting", "Home"), "Composting");
            BreadCrumb.Add("", "Suburban Household");
            return View();
        }

        [HttpGet]
        public ActionResult rural_household()
        {
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("Composting", "Home"), "Composting");
            BreadCrumb.Add("", "Rural Household");
            return View();
        }

        //logic leading to energy quiz page
        [HttpGet]
        public ActionResult EnergyQuiz()
        {
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("Quiz", "Home"), "Household Assessment");
            BreadCrumb.Add("", "Save Energy Assessment");
            return View();
        }

        [HttpGet]
        public ActionResult ReuseQuiz()
        {
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("Quiz", "Home"), "Household Assessment");
            BreadCrumb.Add("", "Reuse Assessment");
            return View();
        }

        [HttpGet]
        public ActionResult ReduceWasteQuiz()
        {
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("Quiz", "Home"), "Household Assessment");
            BreadCrumb.Add("", "Reduce Waste Assessment");
            return View();
        }
    }
}
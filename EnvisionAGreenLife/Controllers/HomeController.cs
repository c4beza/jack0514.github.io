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

        [HttpGet]
        public ActionResult Index()
        {
            BreadCrumb.Clear();
            return View();
        }

        [HttpGet]
        public ActionResult Quiz()
        {
            ViewBag.Message = "How much do you know about saving money and energy?";
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add("", "Quiz");
            return View();
        }

        [HttpGet]
        public ActionResult Reuse()
        {
            ViewBag.Message = "Reuse";
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add("", "Reuse");

            return View();
        }

        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Message = "Description";
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add("", "Learn More");
            return View();
        }

        [HttpGet]
        public ActionResult ReduceFoodWaste()
        {
            ViewBag.Message = "Reduce waste";
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add("", "Reduce Waste");
            return View();
        }

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

        [HttpGet]
        public ActionResult AppliancesType()
        {
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add("", "Save Energy");
            return View();
        }

        [HttpGet]
        public ActionResult Comingsoon()
        {
            BreadCrumb.Clear();
            return View();
        }

        [HttpGet]
        public ActionResult Composting()
        {
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add("", "Composting");
            return View();
        }

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

        [HttpGet]
        public ActionResult EnergyQuiz()
        {
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("Quiz", "Home"), "Quiz");
            BreadCrumb.Add("", "Save Energy Quiz");
            return View();
        }

        [HttpGet]
        public ActionResult ReuseQuiz()
        {
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("Quiz", "Home"), "Quiz");
            BreadCrumb.Add("", "Reuse Quiz");
            return View();
        }

        [HttpGet]
        public ActionResult ReduceWasteQuiz()
        {
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("Quiz", "Home"), "Quiz");
            BreadCrumb.Add("", "Reduce Waste Quiz");
            return View();
        }
    }
}
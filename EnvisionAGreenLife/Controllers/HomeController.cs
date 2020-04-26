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
            BreadCrumb.Add("", "About");
            return View();
        }

        [HttpGet]
        public ActionResult ReduceFoodWaste()
        {
            ViewBag.Message = "Reduce food waste";
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add("", "Reduce Food Waste");
            return View();
        }

        [HttpGet]
        public ActionResult LeftoverRecipe()
        {
            ViewBag.Message = "LeftoverRecipe";
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("ReduceFoodWaste", "Home"), "Reduce Food Waste");
            BreadCrumb.Add("", "Leftover Recipes");
            return View();
        }

        [HttpGet]
        public ActionResult AppliancesType(int? page)
        {
            int pagesize = 9, pageindex = 1;
            pageindex = page.HasValue ? Convert.ToInt32(page) : 1;
            var list = db.appliance_types.OrderByDescending(x => x.Type_Id).ToList();
            IPagedList<appliance_types> stu = list.ToPagedList(pageindex, pagesize);
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add("", "Save Energy");
            return View(stu);
        }
    }
}
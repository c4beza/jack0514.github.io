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

        [BreadCrumb(Clear = true, Label = "Home")]
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Quiz()
        {
            ViewBag.Message = "How much do you know about saving money and energy?";

            return View();
        }

        [HttpGet]
        public ActionResult Reuse()
        {
            ViewBag.Message = "Reuse";

            return View();
        }

        [BreadCrumb(Clear = true, Label = "About")]
        [HttpGet]
        public ActionResult About()
        {
            ViewBag.Message = "Description";

            return View();
        }

        [BreadCrumb(Clear = true, Label = "Reduce Food Waste")]
        [HttpGet]
        public ActionResult ReduceFoodWaste()
        {
            ViewBag.Message = "Reduce food waste";

            return View();
        }

        [BreadCrumb(Clear = true, Label = "Leftover Recipe type")]
        [HttpGet]
        public ActionResult LeftoverRecipe()
        {
            ViewBag.Message = "LeftoverRecipe";

            return View();
        }

        [BreadCrumb(Clear = true, Label = "Appliance Type")]
        [HttpGet]
        public ActionResult AppliancesType(int? page)
        {
            int pagesize = 9, pageindex = 1;
            pageindex = page.HasValue ? Convert.ToInt32(page) : 1;
            var list = db.appliance_types.OrderByDescending(x => x.Type_Id).ToList();
            IPagedList<appliance_types> stu = list.ToPagedList(pageindex, pagesize);
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            return View(stu);
        }
    }
}
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
    public class dishwashersController : Controller
    {
        private AppliancesEntities db = new AppliancesEntities();

        [BreadCrumb(Clear = true, Label = "Dishwasher")]
        [HttpGet]
        public ActionResult Index(int? page, string searchString, string currentFilter)
        {
            var results = from x in db.dishwashers
                          select x;
            int pagesize = 9, pageindex = 1;
            DwList temp = new DwList();
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
                results = results.Where(s => s.Brand.Contains(searchString));
            }
            //if (acList.h1star != false || currentfilter == true)
            //{
            //    results = results.Where(x => x.Star2010_Cool.Value == 3
            //                           );
            //    ViewBag.currentfilter = true;
            //}
            else
            {
                results = results.Where(x => x.Type_Id == 7);
            }

            pageindex = page.HasValue ? Convert.ToInt32(page) : 1;
            var list = results.ToList();
            temp.Dishwashers = list.ToPagedList(pageindex, pagesize);
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("AppliancesType", "Home"), "Save Energy"); 
            return View(temp);
        }

        // GET: dishwashers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dishwasher dishwasher = db.dishwashers.Find(id);
            if (dishwasher == null)
            {
                return HttpNotFound();
            }
            var results = from x in db.dishwashers
                          select x;
            var list = results.Where(x => x.Brand.Contains(dishwasher.Brand)).Take(3).ToList();
            ViewData["SimilarProducts"] = list;
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("AppliancesType", "Home"), "Save Energy");
            BreadCrumb.Add(Url.Action("Index", "dishwashers"), "Dishwasher");
            BreadCrumb.Add("", dishwasher.Model_No);
            return View(dishwasher);
        }
    }
}

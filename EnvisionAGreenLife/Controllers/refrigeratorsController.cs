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
    public class refrigeratorsController : Controller
    {
        private AppliancesEntities db = new AppliancesEntities();

        // GET: refrigerators
        [BreadCrumb(Clear = true, Label = "Refrigerator")]
        [HttpGet]
        public ActionResult Index(int? page, string searchString, string currentFilter)
        {
            var results = from x in db.refrigerators
                          select x;
            int pagesize = 9, pageindex = 1;
            RList temp = new RList();
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
                results = results.Where(x => x.Type_Id == 5);
            }

            pageindex = page.HasValue ? Convert.ToInt32(page) : 1;
            var list = results.ToList();
            temp.Refrigerators = list.ToPagedList(pageindex, pagesize);
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("AppliancesType", "Home"), "Appliance Type");
            return View(temp);
        }

        // GET: refrigerators/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            refrigerator refrigerator = db.refrigerators.Find(id);
            if (refrigerator == null)
            {
                return HttpNotFound();
            }
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("AppliancesType", "Home"), "Appliance Type");
            BreadCrumb.Add(Url.Action("Index", "refrigerators"), "Refrigerator");
            return View(refrigerator);
        }
    }
}

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
    public class monitorsController : Controller
    {
        private AppliancesEntities db = new AppliancesEntities();

        // GET: monitors
        [BreadCrumb(Clear = true, Label = "Monitor")]
        [HttpGet]
        public ActionResult Index(int? page, string searchString, string currentFilter)
        {
            var results = from x in db.monitors
                          select x;
            int pagesize = 9, pageindex = 1;
            MList temp = new MList();
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
                results = results.Where(s => s.Brand_Name.Contains(searchString));
            }
            //if (acList.h1star != false || currentfilter == true)
            //{
            //    results = results.Where(x => x.Star2010_Cool.Value == 3
            //                           );
            //    ViewBag.currentfilter = true;
            //}
            else
            {
                results = results.Where(x => x.Type_Id == 3);
            }

            pageindex = page.HasValue ? Convert.ToInt32(page) : 1;
            var list = results.ToList();
            temp.Monitors = list.ToPagedList(pageindex, pagesize);
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("AppliancesType", "Home"), "Appliance Type");
            BreadCrumb.Add("", "Monitors");
            return View(temp);
        }

        // GET: monitors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            monitor monitor = db.monitors.Find(id);
            if (monitor == null)
            {
                return HttpNotFound();
            }            
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("AppliancesType", "Home"), "Appliance Type");
            BreadCrumb.Add(Url.Action("Index", "monitors"), "Monitor");
            BreadCrumb.Add("", monitor.Model_Number);
            var results = from x in db.monitors
                          select x;
            var list = results.Where(x => x.Brand_Name.Contains(monitor.Brand_Name)).Take(3).ToList();
            ViewData["SimilarProducts"] = list;
            return View(monitor);
        }
    }
}

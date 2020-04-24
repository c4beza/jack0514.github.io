using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EnvisionAGreenLife.Models;
using MvcBreadCrumbs;
using EnvisionAGreenLife.ViewModel;
using PagedList;

namespace EnvisionAGreenLife.Controllers
{
    public class clothes_dryerController : Controller
    {
        private AppliancesEntities db = new AppliancesEntities();

        // GET: clothes_dryer
        [BreadCrumb(Clear = true, Label = "Clothes Dryer")]
        [HttpGet]
        public ActionResult Index(int? page, string searchString, string currentFilter)
        {
            var results = from x in db.clothes_dryer
                          select x;
            int pagesize = 9, pageindex = 1;
            CdList temp = new CdList();
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
                results = results.Where(x => x.Type_Id == 1);
            }

            pageindex = page.HasValue ? Convert.ToInt32(page) : 1;
            var list = results.ToList();
            temp.Clothes_dryers = list.ToPagedList(pageindex, pagesize);
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("AppliancesType", "Home"), "Appliance Type");
            return View(temp);
        }
        // GET: clothes_dryer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clothes_dryer clothes_dryer = db.clothes_dryer.Find(id);
            if (clothes_dryer == null)
            {
                return HttpNotFound();
            }
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("AppliancesType", "Home"), "Appliance Type");
            BreadCrumb.Add(Url.Action("Index", "clothes_dryer"), "Clothes Dryer");
            return View(clothes_dryer);
        }
    }
}

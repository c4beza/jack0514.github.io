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
    public class clothes_washerController : Controller
    {
        private AppliancesEntities db = new AppliancesEntities();

        // GET: clothes_washer
        [BreadCrumb(Clear = true, Label = "Clothes Washer")]
        [HttpGet]
        public ActionResult Index(int? page, string searchString, string currentFilter)
        {
            var results = from x in db.clothes_washer
                          select x;
            int pagesize = 9, pageindex = 1;
            CwList temp = new CwList();
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
                results = results.Where(x => x.Type_Id == 6);
            }

            pageindex = page.HasValue ? Convert.ToInt32(page) : 1;
            var list = results.ToList();
            temp.Clothes_Washers = list.ToPagedList(pageindex, pagesize);
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("AppliancesType", "Home"), "Save Energy");
            return View(temp);
        }
        // GET: clothes_dryer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clothes_washer clothes_Washer = db.clothes_washer.Find(id);
            if (clothes_Washer == null)
            {
                return HttpNotFound();
            }
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("AppliancesType", "Home"), "Save Energy");
            BreadCrumb.Add(Url.Action("Index", "clothes_washer"), "Clothes Washer");
            BreadCrumb.Add("", clothes_Washer.Model_No);
            var results = from x in db.clothes_washer
                          select x;
            var list = results.Where(x => x.Brand.Contains(clothes_Washer.Brand)).Take(3).ToList();
            ViewData["SimilarProducts"] = list;
            return View(clothes_Washer);
        }
    }
}

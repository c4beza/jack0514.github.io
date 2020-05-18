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
    [BreadCrumb]
    public class clothes_washerController : Controller
    {
        private AppliancesEntities db = new AppliancesEntities();

        // GET: clothes_washer
        [BreadCrumb(Clear = true, Label = "Clothes Washer")]
        [HttpGet]
        public ActionResult Index(int? page, string searchString, string currentFilter, string Ratings, string currentRatings)
        {
            decimal rating;
            if (!String.IsNullOrEmpty(Ratings))
            {
                rating = decimal.Parse(Ratings);
            }
            else
            {
                rating = -1;
            }
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
                Ratings = currentRatings;
                searchString = currentFilter;
            }

            // Showing data based on the search query string and the star rating selected from the dropdown.

            ViewData["CurrentRatings"] = Ratings;
            ViewData["CurrentFilter"] = searchString;
            if (!String.IsNullOrEmpty(searchString) && rating != -1)
            {
                results = results.Where(s => s.Brand.Contains(searchString) && s.New_Star < (rating + 1) && s.New_Star >= rating);
            }
            else
            if (!String.IsNullOrEmpty(searchString) && rating == -1)
            {
                results = results.Where(s => s.Brand.Contains(searchString));
            }
            else
            if (String.IsNullOrEmpty(searchString) && rating != -1)
            {
                results = results.Where(s => s.New_Star < (rating + 1) && s.New_Star >= rating);

            }
            else
            {
                results = results.Where(x => x.Type_Id == 6);
            }

            pageindex = page.HasValue ? Convert.ToInt32(page) : 1;
            var list = results.ToList();
            temp.Clothes_Washers = list.ToPagedList(pageindex, pagesize);

            // showing the navigation map using the bread crumbs.

            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("AppliancesType", "Home"), "Save Energy");
            BreadCrumb.Add("", "Clothes Washer");
            List<SelectListItem> Ratings_level = new List<SelectListItem>();

            //adding the values in dropdown list

            Ratings_level.Add(new SelectListItem() { Text = "All Ratings", Value = "-1" });
            Ratings_level.Add(new SelectListItem() { Text = "1 Star", Value = "1" });
            Ratings_level.Add(new SelectListItem() { Text = "2 Star", Value = "2" });
            Ratings_level.Add(new SelectListItem() { Text = "3 Star", Value = "3" });
            Ratings_level.Add(new SelectListItem() { Text = "4 Star", Value = "4" });
            Ratings_level.Add(new SelectListItem() { Text = "5 Star", Value = "5" });
            this.ViewBag.Ratings = new SelectList(Ratings_level, "Value", "Text", currentRatings);
            return View(temp);
        }
        // GET: clothes_dryer/Details/5
        [HttpGet]
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

            // Smiliar products display logic

            var results = from x in db.clothes_washer
                          select x;
            var list = results.Where(x => x.Brand.Contains(clothes_Washer.Brand)).OrderBy(x => Guid.NewGuid()).Take(3).ToList();
            ViewData["SimilarProducts"] = list;
            return View(clothes_Washer);
        }

        // GET: Top recommendations
        [HttpGet]
        public ActionResult TopRecommendations()
        {

            var results = from x in db.clothes_washer
                          select x;
            int pagesize = 9, pageindex = 1;
            CwList temp = new CwList();
            results = results.Where(x => x.New_Star >= 5).OrderBy(x => Guid.NewGuid()).Take(9);
            var list = results.ToList();
            temp.Clothes_Washers = list.ToPagedList(pageindex, pagesize);
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("AppliancesType", "Home"), "Save Energy");
            BreadCrumb.Add(Url.Action("Index", "clothes_washer"), "Clothes Washer");
            BreadCrumb.Add("", "Top Recommendations");
            List<SelectListItem> Ratings_level = new List<SelectListItem>();
            Ratings_level.Add(new SelectListItem() { Text = "All Ratings", Value = "-1" });
            Ratings_level.Add(new SelectListItem() { Text = "1 Star", Value = "1" });
            Ratings_level.Add(new SelectListItem() { Text = "2 Star", Value = "2" });
            Ratings_level.Add(new SelectListItem() { Text = "3 Star", Value = "3" });
            Ratings_level.Add(new SelectListItem() { Text = "4 Star", Value = "4" });
            Ratings_level.Add(new SelectListItem() { Text = "5 Star", Value = "5" });
            this.ViewBag.Ratings = new SelectList(Ratings_level, "Value", "Text");
            return View(temp);
        }
    }
}

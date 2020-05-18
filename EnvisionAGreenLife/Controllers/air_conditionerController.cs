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
    [BreadCrumb]
    public class air_conditionerController : Controller
    {
        private AppliancesEntities db = new AppliancesEntities();

        // GET: air_conditioner
        [BreadCrumb(Clear = true, Label = "Air Conditioner")]
        [HttpGet]
        public ActionResult Index(int? page, string searchString, string currentFilter, string Ratings, string currentRatings)
        {
            // Display the data based on the selected seach filter.
            decimal rating;
            if (!String.IsNullOrEmpty(Ratings))
            {
                rating = decimal.Parse(Ratings);
            }
            else
            {
                rating = -1;
            }
            var results = from x in db.air_conditioner
                          select x;
            int pagesize = 9, pageindex = 1;
            AcList temp = new AcList();
            if (searchString != null || rating != -1)
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
                results = results.Where(s => s.Brand.Contains(searchString) && s.Star2010_Cool < (rating + 1) && s.Star2010_Cool >= rating);
            }
            else
            if (!String.IsNullOrEmpty(searchString) && rating == -1)
            {
                results = results.Where(s => s.Brand.Contains(searchString));
            }
            else
            if (String.IsNullOrEmpty(searchString) && rating != -1)
            {
                results = results.Where(s => s.Star2010_Cool < (rating + 1) && s.Star2010_Cool >= rating);

            }
            else
            {
                results = results.Where(x => x.Type_Id == 2);
            }

            pageindex = page.HasValue ? Convert.ToInt32(page) : 1;
            var list = results.ToList();
            temp.Air_Conditioners = list.ToPagedList(pageindex, pagesize);

            // showing the navigation map using the bread crumbs.
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("AppliancesType", "Home"), "Save Energy");
            BreadCrumb.Add("", "Air Conditioner");

            //adding the values in dropdown list

            List<SelectListItem> Ratings_level = new List<SelectListItem>();
            Ratings_level.Add(new SelectListItem() { Text = "All Ratings", Value = "-1" });
            Ratings_level.Add(new SelectListItem() { Text = "1 Star", Value = "1" });
            Ratings_level.Add(new SelectListItem() { Text = "2 Star", Value = "2" });
            Ratings_level.Add(new SelectListItem() { Text = "3 Star", Value = "3" });
            Ratings_level.Add(new SelectListItem() { Text = "4 Star", Value = "4" });
            Ratings_level.Add(new SelectListItem() { Text = "5 Star", Value = "5" });
            this.ViewBag.Ratings = new SelectList(Ratings_level, "Value", "Text", currentRatings);
            return View(temp);
        }
        // GET: air_conditioner/Details/5
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            air_conditioner air_conditioner = db.air_conditioner.Find(id);
            if (air_conditioner == null)
            {
                return HttpNotFound();
            }
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("AppliancesType", "Home"), "Save Energy");
            BreadCrumb.Add(Url.Action("Index", "air_conditioner"), "Air Conditioner");
            BreadCrumb.Add("", air_conditioner.Model_No);

            // Smiliar products display logic

            var results = from x in db.air_conditioner
                          select x;
            var list = results.Where(x => x.Brand.Contains(air_conditioner.Brand)).OrderBy(x => Guid.NewGuid()).Take(3).ToList();
            ViewData["SimilarProducts"] = list;
            return View(air_conditioner);
        }

        // GET: Top recommendations
        [HttpGet]
        public ActionResult TopRecommendations()
        {
            
            var results = from x in db.air_conditioner
                          select x;
            int pagesize = 9, pageindex = 1;
            AcList temp = new AcList();
            results = results.Where(x => x.sri2010_cool >= 5).OrderBy(x => Guid.NewGuid()).Take(9);
            var list = results.ToList();
            temp.Air_Conditioners = list.ToPagedList(pageindex, pagesize);
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("AppliancesType", "Home"), "Save Energy");
            BreadCrumb.Add(Url.Action("Index", "air_conditioner"), "Air Conditioner");
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

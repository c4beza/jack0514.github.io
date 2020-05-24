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
    public class dishwashersController : Controller
    {
        private AppliancesEntities db = new AppliancesEntities();

        // GET: dishwasher
        [BreadCrumb(Clear = true, Label = "Dishwasher")]
        [HttpGet]
        public ActionResult Index(int? page, string searchString, string currentFilter, string Ratings, string currentRatings)
        {
            decimal rating;
            if (!String.IsNullOrEmpty(Ratings))
            {
                rating = decimal.Parse(Ratings);
            }
            else
            if (!String.IsNullOrEmpty(currentRatings))
            {
                rating = decimal.Parse(currentRatings);
            }
            else
            {
                rating = -1;
            }
            var results = from x in db.dishwashers
                          select x;
            int pagesize = 9, pageindex = 1;
            DwList temp = new DwList();
            if (searchString != null || Ratings != null)
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
                results = results.Where(x => x.Type_Id == 7);
            }

            pageindex = page.HasValue ? Convert.ToInt32(page) : 1;
            var list = results.ToList();
            temp.Dishwashers = list.ToPagedList(pageindex, pagesize);

            // showing the navigation map using the bread crumbs.

            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("AppliancesType", "Home"), "Save Energy");
            BreadCrumb.Add("", "Dishwasher");
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

        // GET: dishwashers/Details/5
        [HttpGet]
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
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("AppliancesType", "Home"), "Save Energy");
            BreadCrumb.Add(Url.Action("Index", "dishwashers"), "Dishwasher");
            BreadCrumb.Add("", dishwasher.Model_No);

            // Smiliar products display logic

            var results = from x in db.dishwashers
                          select x;
            var list = results.Where(x => x.Brand.Contains(dishwasher.Brand)).OrderBy(x => Guid.NewGuid()).Take(3).ToList();
            ViewData["SimilarProducts"] = list;
            return View(dishwasher);
        }

        // GET: Top recommendations
        [HttpGet]
        public ActionResult TopRecommendations()
        {

            var results = from x in db.dishwashers
                          select x;
            int pagesize = 9, pageindex = 1;
            DwList temp = new DwList();
            results = results.Where(x => x.New_Star >= 4).OrderBy(x => Guid.NewGuid()).Take(9);
            var list = results.ToList();
            temp.Dishwashers = list.ToPagedList(pageindex, pagesize);
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("AppliancesType", "Home"), "Save Energy");
            BreadCrumb.Add(Url.Action("Index", "dishwashers"), "Dishwasher");
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

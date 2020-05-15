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

namespace EnvisionAGreenLife.Controllers
{
    public class HerbsController : Controller
    {
        private LeftoverRecipesEntities db = new LeftoverRecipesEntities();

        // GET: Herbs
        public ActionResult Index()
        {
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("ReduceFoodWaste", "Home"), "Reduce Food Waste");
            BreadCrumb.Add(Url.Action(""), "Grow Your Own Herb");
            return View(db.Herbs.ToList());
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Herb herbs = db.Herbs.Find(id);
            if (herbs == null)
            {
                return HttpNotFound();
            }
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add(Url.Action("ReduceFoodWaste", "Home"), "Reduce Food Waste");
            BreadCrumb.Add(Url.Action("Index", "Herbs"), "Grow Your Own Herb");
            BreadCrumb.Add("", herbs.Herb_Categories);
            return View(herbs);
        }
    }
}

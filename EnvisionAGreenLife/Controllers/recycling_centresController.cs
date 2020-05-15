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
    public class recycling_centresController : Controller
    {
        private RecyclingCentre_dbEntities db = new RecyclingCentre_dbEntities();

        // GET: recycling_centres
        public ActionResult Index()
        {
            BreadCrumb.Clear();
            BreadCrumb.Add(Url.Action("Index", "Home"), "Home");
            BreadCrumb.Add("", "Recycling centre map");
            return View(db.recycling_centres.ToList());
        }
    }
}

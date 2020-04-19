using PagedList;
using EnvisionAGreenLife.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnvisionAGreenLife.Controllers
{
    public class HomeController : Controller
    {
        AppliancesEntities db = new AppliancesEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Quiz()
        {
            ViewBag.Message = "How much do you know about saving money and energy?";

            return View();
        }

        public ActionResult Reuse()
        {
            ViewBag.Message = "Reuse";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Description";

            return View();
        }

        public ActionResult Energy()
        {
            ViewBag.Message = "Save Energy";

            return View();
        }

        public ActionResult Food()
        {
            ViewBag.Message = "Reduce food waste";

            return View();
        }
        public ActionResult AppliancesType(int? page)
        {
            int pagesize = 9, pageindex = 1;
            pageindex = page.HasValue ? Convert.ToInt32(page) : 1;
            var list = db.appliance_types.OrderByDescending(x => x.Type_Id).ToList();
            IPagedList<appliance_types> stu = list.ToPagedList(pageindex, pagesize);
            return View(stu);
        }

        public ActionResult Products(int? id, int? page)
        {
            int pagesize = 9, pageindex = 1;
            pageindex = page.HasValue ? Convert.ToInt32(page) : 1;            
                var list = db.clothes_dryer.Where(x => x.Type_Id == id).OrderByDescending(x => x.Clothes_Dryer_Id).ToList();
                IPagedList<clothes_dryer> stu = list.ToPagedList(pageindex, pagesize);
            

            



            return View(stu);


        }
    }
}
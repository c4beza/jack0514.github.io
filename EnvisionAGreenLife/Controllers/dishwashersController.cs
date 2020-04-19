using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EnvisionAGreenLife.Models;

namespace EnvisionAGreenLife.Controllers
{
    public class dishwashersController : Controller
    {
        private AppliancesEntities db = new AppliancesEntities();

        // GET: dishwashers
        public ActionResult Index()
        {
            var dishwashers = db.dishwashers.Include(d => d.appliance_types);
            return View(dishwashers.ToList());
        }

        // GET: dishwashers/Details/5
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
            return View(dishwasher);
        }

        // GET: dishwashers/Create
        public ActionResult Create()
        {
            ViewBag.Type_Id = new SelectList(db.appliance_types, "Type_Id", "Type_Name");
            return View();
        }

        // POST: dishwashers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Dishwasher_Id,ApplStandard,Brand,Cap,CEC,Conn_Type,Country,delayStartMode,Depth,Height,Load_Type,Model_No,Family_Name,N_Standard,New_SRI,New_Star,postProgenergy,powerConsMode,Prog_Name,Prog_Time,Sold_in,standbyPowerUsage,Submit_ID,SubmitStatus,Tot_Wat_Cons,Type,Water_Softener,Width,ExpDate,GrandDate,Product_Class,Availability_Status,Product_Website,Representative_Brand_URL,Water_Consumption_litres,Star_Rating_old,Star_Image_Large,Star_Image_Small,Type_Id")] dishwasher dishwasher)
        {
            if (ModelState.IsValid)
            {
                db.dishwashers.Add(dishwasher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Type_Id = new SelectList(db.appliance_types, "Type_Id", "Type_Name", dishwasher.Type_Id);
            return View(dishwasher);
        }

        // GET: dishwashers/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.Type_Id = new SelectList(db.appliance_types, "Type_Id", "Type_Name", dishwasher.Type_Id);
            return View(dishwasher);
        }

        // POST: dishwashers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Dishwasher_Id,ApplStandard,Brand,Cap,CEC,Conn_Type,Country,delayStartMode,Depth,Height,Load_Type,Model_No,Family_Name,N_Standard,New_SRI,New_Star,postProgenergy,powerConsMode,Prog_Name,Prog_Time,Sold_in,standbyPowerUsage,Submit_ID,SubmitStatus,Tot_Wat_Cons,Type,Water_Softener,Width,ExpDate,GrandDate,Product_Class,Availability_Status,Product_Website,Representative_Brand_URL,Water_Consumption_litres,Star_Rating_old,Star_Image_Large,Star_Image_Small,Type_Id")] dishwasher dishwasher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dishwasher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Type_Id = new SelectList(db.appliance_types, "Type_Id", "Type_Name", dishwasher.Type_Id);
            return View(dishwasher);
        }

        // GET: dishwashers/Delete/5
        public ActionResult Delete(int? id)
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
            return View(dishwasher);
        }

        // POST: dishwashers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            dishwasher dishwasher = db.dishwashers.Find(id);
            db.dishwashers.Remove(dishwasher);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

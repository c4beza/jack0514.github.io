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
    public class monitorsController : Controller
    {
        private AppliancesEntities db = new AppliancesEntities();

        // GET: monitors
        public ActionResult Index()
        {
            var monitors = db.monitors.Include(m => m.appliance_types);
            return View(monitors.ToList());
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
            return View(monitor);
        }

        // GET: monitors/Create
        public ActionResult Create()
        {
            ViewBag.Type_Id = new SelectList(db.appliance_types, "Type_Id", "Type_Name");
            return View();
        }

        // POST: monitors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Monitor_Id,Record_ID,Status,Brand_Name,Model_Number,Family_Name,Selling_Countries,Manufacturing_Countries,Screen_Size,Screen_Technology,Comparative_Energy_Consumption,Active_Standby_Power,Star_Rating_Index,Star_Rating,Product_Website,Representative_Brand_URL,Availability_Status,Expiry_Date,Star_Image_Large,Star_Image_Small,Type_Id")] monitor monitor)
        {
            if (ModelState.IsValid)
            {
                db.monitors.Add(monitor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Type_Id = new SelectList(db.appliance_types, "Type_Id", "Type_Name", monitor.Type_Id);
            return View(monitor);
        }

        // GET: monitors/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.Type_Id = new SelectList(db.appliance_types, "Type_Id", "Type_Name", monitor.Type_Id);
            return View(monitor);
        }

        // POST: monitors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Monitor_Id,Record_ID,Status,Brand_Name,Model_Number,Family_Name,Selling_Countries,Manufacturing_Countries,Screen_Size,Screen_Technology,Comparative_Energy_Consumption,Active_Standby_Power,Star_Rating_Index,Star_Rating,Product_Website,Representative_Brand_URL,Availability_Status,Expiry_Date,Star_Image_Large,Star_Image_Small,Type_Id")] monitor monitor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(monitor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Type_Id = new SelectList(db.appliance_types, "Type_Id", "Type_Name", monitor.Type_Id);
            return View(monitor);
        }

        // GET: monitors/Delete/5
        public ActionResult Delete(int? id)
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
            return View(monitor);
        }

        // POST: monitors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            monitor monitor = db.monitors.Find(id);
            db.monitors.Remove(monitor);
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

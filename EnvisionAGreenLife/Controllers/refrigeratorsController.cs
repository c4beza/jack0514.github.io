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
    public class refrigeratorsController : Controller
    {
        private AppliancesEntities db = new AppliancesEntities();

        // GET: refrigerators
        public ActionResult Index()
        {
            var refrigerators = db.refrigerators.Include(r => r.appliance_types);
            return View(refrigerators.ToList());
        }

        // GET: refrigerators/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            refrigerator refrigerator = db.refrigerators.Find(id);
            if (refrigerator == null)
            {
                return HttpNotFound();
            }
            return View(refrigerator);
        }

        // GET: refrigerators/Create
        public ActionResult Create()
        {
            ViewBag.Type_Id = new SelectList(db.appliance_types, "Type_Id", "Type_Name");
            return View();
        }

        // POST: refrigerators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Refrigerator_Id,Adaptive_Defrost,ApplStandard,Brand,CEC,CompartGrVol,CompartNetVol,CompartType,Configuration,Country,Depth,Designation,FF_Vol,FZ_Vol,Group,Height,Icemaker,MEPSApproval,Model_No,Family_Name,N_Standard,Star2009,SRI2009,No_Doors,S_MEPS_Ad,S_MEPScutoff,Sold_in,Submit_ID,SubmitStatus,Tot_Vol,Width,ExpDate,GrandDate,Product_Class,Availability_Status,Product_Website,Representative_Brand_URL,Fixed_MEPS_allowance_factor,Variable_MEPS_allowance_factor,Adjusted_volume,Type,Star_Rating_old,Star_Image_Large,Star_Image_Small,Registration_Number,Type_Id")] refrigerator refrigerator)
        {
            if (ModelState.IsValid)
            {
                db.refrigerators.Add(refrigerator);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Type_Id = new SelectList(db.appliance_types, "Type_Id", "Type_Name", refrigerator.Type_Id);
            return View(refrigerator);
        }

        // GET: refrigerators/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            refrigerator refrigerator = db.refrigerators.Find(id);
            if (refrigerator == null)
            {
                return HttpNotFound();
            }
            ViewBag.Type_Id = new SelectList(db.appliance_types, "Type_Id", "Type_Name", refrigerator.Type_Id);
            return View(refrigerator);
        }

        // POST: refrigerators/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Refrigerator_Id,Adaptive_Defrost,ApplStandard,Brand,CEC,CompartGrVol,CompartNetVol,CompartType,Configuration,Country,Depth,Designation,FF_Vol,FZ_Vol,Group,Height,Icemaker,MEPSApproval,Model_No,Family_Name,N_Standard,Star2009,SRI2009,No_Doors,S_MEPS_Ad,S_MEPScutoff,Sold_in,Submit_ID,SubmitStatus,Tot_Vol,Width,ExpDate,GrandDate,Product_Class,Availability_Status,Product_Website,Representative_Brand_URL,Fixed_MEPS_allowance_factor,Variable_MEPS_allowance_factor,Adjusted_volume,Type,Star_Rating_old,Star_Image_Large,Star_Image_Small,Registration_Number,Type_Id")] refrigerator refrigerator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(refrigerator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Type_Id = new SelectList(db.appliance_types, "Type_Id", "Type_Name", refrigerator.Type_Id);
            return View(refrigerator);
        }

        // GET: refrigerators/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            refrigerator refrigerator = db.refrigerators.Find(id);
            if (refrigerator == null)
            {
                return HttpNotFound();
            }
            return View(refrigerator);
        }

        // POST: refrigerators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            refrigerator refrigerator = db.refrigerators.Find(id);
            db.refrigerators.Remove(refrigerator);
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

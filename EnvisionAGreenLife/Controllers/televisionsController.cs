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
    public class televisionsController : Controller
    {
        private AppliancesEntities db = new AppliancesEntities();

        // GET: televisions
        public ActionResult Index()
        {
            var televisions = db.televisions.Include(t => t.appliance_types);
            return View(televisions.ToList());
        }

        // GET: televisions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            television television = db.televisions.Find(id);
            if (television == null)
            {
                return HttpNotFound();
            }
            return View(television);
        }

        // GET: televisions/Create
        public ActionResult Create()
        {
            ViewBag.Type_Id = new SelectList(db.appliance_types, "Type_Id", "Type_Name");
            return View();
        }

        // POST: televisions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Television_Id,Submit_ID,Brand_Reg,Model_No,Family_Name,SoldIn,Country,screensize,Screen_Area,Screen_Tech,Pasv_stnd_power,Act_stnd_power,Act_stnd_time,Avg_mode_power,Star,SRI,CEC,SubmitStatus,ExpDate,GrandDate,Product_Class,Availability_Status,Star2,Product_Website,Representative_Brand_URL,Star_Rating_Index,Star_Image_Large,Star_Image_Small,Power_supply,Tuner_Type,What_test_standard_was_used,Registration_Number,Type_Id")] television television)
        {
            if (ModelState.IsValid)
            {
                db.televisions.Add(television);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Type_Id = new SelectList(db.appliance_types, "Type_Id", "Type_Name", television.Type_Id);
            return View(television);
        }

        // GET: televisions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            television television = db.televisions.Find(id);
            if (television == null)
            {
                return HttpNotFound();
            }
            ViewBag.Type_Id = new SelectList(db.appliance_types, "Type_Id", "Type_Name", television.Type_Id);
            return View(television);
        }

        // POST: televisions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Television_Id,Submit_ID,Brand_Reg,Model_No,Family_Name,SoldIn,Country,screensize,Screen_Area,Screen_Tech,Pasv_stnd_power,Act_stnd_power,Act_stnd_time,Avg_mode_power,Star,SRI,CEC,SubmitStatus,ExpDate,GrandDate,Product_Class,Availability_Status,Star2,Product_Website,Representative_Brand_URL,Star_Rating_Index,Star_Image_Large,Star_Image_Small,Power_supply,Tuner_Type,What_test_standard_was_used,Registration_Number,Type_Id")] television television)
        {
            if (ModelState.IsValid)
            {
                db.Entry(television).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Type_Id = new SelectList(db.appliance_types, "Type_Id", "Type_Name", television.Type_Id);
            return View(television);
        }

        // GET: televisions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            television television = db.televisions.Find(id);
            if (television == null)
            {
                return HttpNotFound();
            }
            return View(television);
        }

        // POST: televisions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            television television = db.televisions.Find(id);
            db.televisions.Remove(television);
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

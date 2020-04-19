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
    public class clothes_washerController : Controller
    {
        private AppliancesEntities db = new AppliancesEntities();

        // GET: clothes_washer
        public ActionResult Index()
        {
            var clothes_washer = db.clothes_washer.Include(c => c.appliance_types);
            return View(clothes_washer.ToList());
        }

        // GET: clothes_washer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clothes_washer clothes_washer = db.clothes_washer.Find(id);
            if (clothes_washer == null)
            {
                return HttpNotFound();
            }
            return View(clothes_washer);
        }

        // GET: clothes_washer/Create
        public ActionResult Create()
        {
            ViewBag.Type_Id = new SelectList(db.appliance_types, "Type_Id", "Type_Name");
            return View();
        }

        // POST: clothes_washer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Clothes_Washer_Id,ApplStandard,Brand,Cap,Cap_Second_Drum,CEC_Cold,CEC_Cold_Second_Drum,CEC,CEC_Second_Drum,Cold_Prog,Cold_Prog_Second_Drum,Cold_Wat_Cons,Cold_Wat_Cons_Second_Drum,Combination,Combination_Second_Drum,Conn_Mode,Conn_Mode_Second_Drum,Country,delayStartMode,delayStartMode_Second_Drum,Depth,Depth_Second_Drum,DetergentType,DetergentType_Second_Drum,Height,Height_Second_Drum,Hot_Wat_Cons,Hot_Wat_Cons_Second_Drum,internal_heater,internal_heater_Second_Drum,Loading,Loading_Second_Drum,MachineAction,MachineAction_Second_Drum,Model_No,Family_Name,N_Standard,New_SRI,New_SRI_Second_Drum,New_Star,New_Star_Second_Drum,postProgenergy,postProgenergy_Second_Drum,powerConsMode,powerConsMode_Second_Drum,Prog_Name,Prog_Name_Second_Drum,Sold_in,standbyPowerUsage,standbyPowerUsage_Second_Drum,Submit_ID,SubmitStatus,Test_Prog_Time,Test_Prog_Time_Second_Drum,Tot_Wat_Cons,Tot_Wat_Cons_Second_Drum,Type,Type_Second_Drum,WEI,WEI_Second_Drum,Width,Width_Second_Drum,ExpDate,GrandDate,Product_Class,Availability_Status,Product_Website,Representative_Brand_URL,Program_Time,Program_Time_Second_Drum,Hot_Water_L,Hot_Water_L_Second_Drum,Cold_Water_L,Cold_Water_L_Second_Drum,Star_Rating_old,Star_Image_Large,Star_Image_Large_Second_Drum,Star_Image_Small,Star_Image_Small_Second_Drum,Registration_Number,Type_Id")] clothes_washer clothes_washer)
        {
            if (ModelState.IsValid)
            {
                db.clothes_washer.Add(clothes_washer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Type_Id = new SelectList(db.appliance_types, "Type_Id", "Type_Name", clothes_washer.Type_Id);
            return View(clothes_washer);
        }

        // GET: clothes_washer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clothes_washer clothes_washer = db.clothes_washer.Find(id);
            if (clothes_washer == null)
            {
                return HttpNotFound();
            }
            ViewBag.Type_Id = new SelectList(db.appliance_types, "Type_Id", "Type_Name", clothes_washer.Type_Id);
            return View(clothes_washer);
        }

        // POST: clothes_washer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Clothes_Washer_Id,ApplStandard,Brand,Cap,Cap_Second_Drum,CEC_Cold,CEC_Cold_Second_Drum,CEC,CEC_Second_Drum,Cold_Prog,Cold_Prog_Second_Drum,Cold_Wat_Cons,Cold_Wat_Cons_Second_Drum,Combination,Combination_Second_Drum,Conn_Mode,Conn_Mode_Second_Drum,Country,delayStartMode,delayStartMode_Second_Drum,Depth,Depth_Second_Drum,DetergentType,DetergentType_Second_Drum,Height,Height_Second_Drum,Hot_Wat_Cons,Hot_Wat_Cons_Second_Drum,internal_heater,internal_heater_Second_Drum,Loading,Loading_Second_Drum,MachineAction,MachineAction_Second_Drum,Model_No,Family_Name,N_Standard,New_SRI,New_SRI_Second_Drum,New_Star,New_Star_Second_Drum,postProgenergy,postProgenergy_Second_Drum,powerConsMode,powerConsMode_Second_Drum,Prog_Name,Prog_Name_Second_Drum,Sold_in,standbyPowerUsage,standbyPowerUsage_Second_Drum,Submit_ID,SubmitStatus,Test_Prog_Time,Test_Prog_Time_Second_Drum,Tot_Wat_Cons,Tot_Wat_Cons_Second_Drum,Type,Type_Second_Drum,WEI,WEI_Second_Drum,Width,Width_Second_Drum,ExpDate,GrandDate,Product_Class,Availability_Status,Product_Website,Representative_Brand_URL,Program_Time,Program_Time_Second_Drum,Hot_Water_L,Hot_Water_L_Second_Drum,Cold_Water_L,Cold_Water_L_Second_Drum,Star_Rating_old,Star_Image_Large,Star_Image_Large_Second_Drum,Star_Image_Small,Star_Image_Small_Second_Drum,Registration_Number,Type_Id")] clothes_washer clothes_washer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clothes_washer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Type_Id = new SelectList(db.appliance_types, "Type_Id", "Type_Name", clothes_washer.Type_Id);
            return View(clothes_washer);
        }

        // GET: clothes_washer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clothes_washer clothes_washer = db.clothes_washer.Find(id);
            if (clothes_washer == null)
            {
                return HttpNotFound();
            }
            return View(clothes_washer);
        }

        // POST: clothes_washer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            clothes_washer clothes_washer = db.clothes_washer.Find(id);
            db.clothes_washer.Remove(clothes_washer);
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

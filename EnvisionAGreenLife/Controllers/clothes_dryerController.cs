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
    public class clothes_dryerController : Controller
    {
        private AppliancesEntities db = new AppliancesEntities();

        // GET: clothes_dryer
        public ActionResult Index()
        {
            var clothes_dryer = db.clothes_dryer.Include(c => c.appliance_types);
            return View(clothes_dryer.ToList());
        }

        // GET: clothes_dryer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clothes_dryer clothes_dryer = db.clothes_dryer.Find(id);
            if (clothes_dryer == null)
            {
                return HttpNotFound();
            }
            return View(clothes_dryer);
        }

        // GET: clothes_dryer/Create
        public ActionResult Create()
        {
            ViewBag.Type_Id = new SelectList(db.appliance_types, "Type_Id", "Type_Name");
            return View();
        }

        // POST: clothes_dryer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Clothes_Dryer_Id,ApplStandard,Brand,Cap,Combination,Control,Country,Depth,Height,Model_No,Family_Name,N_Standard,New_CEC,New_SRI,New_Star,Prog_Name,Prog_Time,Sold_in,SubmitStatus,Submit_ID,Test_Moist_Remove,Tot_Wat_Cons,Type,Width,ExpDate,GrandDate,Product_Class,Availability_Status,Product_Website,Representative_Brand_URL,Star_Rating_old,Star_Image_Large,Star_Image_Small,Type_Id")] clothes_dryer clothes_dryer)
        {
            if (ModelState.IsValid)
            {
                db.clothes_dryer.Add(clothes_dryer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Type_Id = new SelectList(db.appliance_types, "Type_Id", "Type_Name", clothes_dryer.Type_Id);
            return View(clothes_dryer);
        }

        // GET: clothes_dryer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clothes_dryer clothes_dryer = db.clothes_dryer.Find(id);
            if (clothes_dryer == null)
            {
                return HttpNotFound();
            }
            ViewBag.Type_Id = new SelectList(db.appliance_types, "Type_Id", "Type_Name", clothes_dryer.Type_Id);
            return View(clothes_dryer);
        }

        // POST: clothes_dryer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Clothes_Dryer_Id,ApplStandard,Brand,Cap,Combination,Control,Country,Depth,Height,Model_No,Family_Name,N_Standard,New_CEC,New_SRI,New_Star,Prog_Name,Prog_Time,Sold_in,SubmitStatus,Submit_ID,Test_Moist_Remove,Tot_Wat_Cons,Type,Width,ExpDate,GrandDate,Product_Class,Availability_Status,Product_Website,Representative_Brand_URL,Star_Rating_old,Star_Image_Large,Star_Image_Small,Type_Id")] clothes_dryer clothes_dryer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clothes_dryer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Type_Id = new SelectList(db.appliance_types, "Type_Id", "Type_Name", clothes_dryer.Type_Id);
            return View(clothes_dryer);
        }

        // GET: clothes_dryer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clothes_dryer clothes_dryer = db.clothes_dryer.Find(id);
            if (clothes_dryer == null)
            {
                return HttpNotFound();
            }
            return View(clothes_dryer);
        }

        // POST: clothes_dryer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            clothes_dryer clothes_dryer = db.clothes_dryer.Find(id);
            db.clothes_dryer.Remove(clothes_dryer);
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

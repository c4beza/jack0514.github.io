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
    public class recycling_centresController : Controller
    {
        private RecyclingCentresEntities db = new RecyclingCentresEntities();

        // GET: recycling_centres
        public ActionResult Index()
        {
            return View(db.recycling_centres.ToList());
        }

        // GET: recycling_centres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recycling_centres recycling_centres = db.recycling_centres.Find(id);
            if (recycling_centres == null)
            {
                return HttpNotFound();
            }
            return View(recycling_centres);
        }

        // GET: recycling_centres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: recycling_centres/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Address,Lattitude,Longitude,CentresId")] recycling_centres recycling_centres)
        {
            if (ModelState.IsValid)
            {
                db.recycling_centres.Add(recycling_centres);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recycling_centres);
        }

        // GET: recycling_centres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recycling_centres recycling_centres = db.recycling_centres.Find(id);
            if (recycling_centres == null)
            {
                return HttpNotFound();
            }
            return View(recycling_centres);
        }

        // POST: recycling_centres/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Address,Lattitude,Longitude,CentresId")] recycling_centres recycling_centres)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recycling_centres).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recycling_centres);
        }

        // GET: recycling_centres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            recycling_centres recycling_centres = db.recycling_centres.Find(id);
            if (recycling_centres == null)
            {
                return HttpNotFound();
            }
            return View(recycling_centres);
        }

        // POST: recycling_centres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            recycling_centres recycling_centres = db.recycling_centres.Find(id);
            db.recycling_centres.Remove(recycling_centres);
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

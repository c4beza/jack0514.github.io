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
    public class air_conditionerController : Controller
    {
        private AppliancesEntities db = new AppliancesEntities();

        // GET: air_conditioner
        public ActionResult Index()
        {
            var air_conditioner = db.air_conditioner.Include(a => a.appliance_types);
            return View(air_conditioner.ToList());
        }

        // GET: air_conditioner/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            air_conditioner air_conditioner = db.air_conditioner.Find(id);
            if (air_conditioner == null)
            {
                return HttpNotFound();
            }
            return View(air_conditioner);
        }

        // GET: air_conditioner/Create
        public ActionResult Create()
        {
            ViewBag.Type_Id = new SelectList(db.appliance_types, "Type_Id", "Type_Name");
            return View();
        }

        // POST: air_conditioner/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Air_Conditioner_Id,ApplStandard,MEPSComp,N_Standard,Model_No,Family_Name,avg_pwr_standby_mode,Brand,C_Dehumid_Rated,Configuration1,Configuration2,Configuration2_unitmount,Configuration3_Sink,Configuration3_Source,Country,C_Power_Inp_Rated,C_Sens_Cool_Rated,C_Total_Cool_Rated,Depth,H2_COP,H2_HeatPwrCapacity,H2_HeatPwrInput,Height,H_Power_Inp_Rated,H_Total_Heat_Rated,indoorType,EERtestAvg,COPtestAvg,Invert,Setting_cool,Setting_heat,Pnoc,Pnoh,VSCP_EER50,VSCP_COP50,AnnualOutputEER,AnnualOutputCOP,sri2010_cool,sri2010_heat,Star2010_Cool,Star2010_Heat,outdoortype,Phase,Refrigerant,Sold_in,Submit_ID,ExpDate,GrandDate,SubmitStatus,Type,Width,Product_Class,Demand_Response_1,Demand_Response_2,Demand_Response_4,Demand_Response_5,Demand_Response_6,Demand_Response_7,PartNumber,EER,Availability_Status,star2000_cool,star2000_heat,Product_Website,Representative_Brand_URL,Variable_Output_Compressor,Star_Image_Large,Star_Image_Small,Registration_Number,Is_variable_speed,Type_variable_output,Var_output_compressor,Rated_cooling_power_input_kW,Rated_heating_power_input_kW,Rated_AEER,Rated_ACOP,Type_Id")] air_conditioner air_conditioner)
        {
            if (ModelState.IsValid)
            {
                db.air_conditioner.Add(air_conditioner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Type_Id = new SelectList(db.appliance_types, "Type_Id", "Type_Name", air_conditioner.Type_Id);
            return View(air_conditioner);
        }

        // GET: air_conditioner/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            air_conditioner air_conditioner = db.air_conditioner.Find(id);
            if (air_conditioner == null)
            {
                return HttpNotFound();
            }
            ViewBag.Type_Id = new SelectList(db.appliance_types, "Type_Id", "Type_Name", air_conditioner.Type_Id);
            return View(air_conditioner);
        }

        // POST: air_conditioner/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Air_Conditioner_Id,ApplStandard,MEPSComp,N_Standard,Model_No,Family_Name,avg_pwr_standby_mode,Brand,C_Dehumid_Rated,Configuration1,Configuration2,Configuration2_unitmount,Configuration3_Sink,Configuration3_Source,Country,C_Power_Inp_Rated,C_Sens_Cool_Rated,C_Total_Cool_Rated,Depth,H2_COP,H2_HeatPwrCapacity,H2_HeatPwrInput,Height,H_Power_Inp_Rated,H_Total_Heat_Rated,indoorType,EERtestAvg,COPtestAvg,Invert,Setting_cool,Setting_heat,Pnoc,Pnoh,VSCP_EER50,VSCP_COP50,AnnualOutputEER,AnnualOutputCOP,sri2010_cool,sri2010_heat,Star2010_Cool,Star2010_Heat,outdoortype,Phase,Refrigerant,Sold_in,Submit_ID,ExpDate,GrandDate,SubmitStatus,Type,Width,Product_Class,Demand_Response_1,Demand_Response_2,Demand_Response_4,Demand_Response_5,Demand_Response_6,Demand_Response_7,PartNumber,EER,Availability_Status,star2000_cool,star2000_heat,Product_Website,Representative_Brand_URL,Variable_Output_Compressor,Star_Image_Large,Star_Image_Small,Registration_Number,Is_variable_speed,Type_variable_output,Var_output_compressor,Rated_cooling_power_input_kW,Rated_heating_power_input_kW,Rated_AEER,Rated_ACOP,Type_Id")] air_conditioner air_conditioner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(air_conditioner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Type_Id = new SelectList(db.appliance_types, "Type_Id", "Type_Name", air_conditioner.Type_Id);
            return View(air_conditioner);
        }

        // GET: air_conditioner/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            air_conditioner air_conditioner = db.air_conditioner.Find(id);
            if (air_conditioner == null)
            {
                return HttpNotFound();
            }
            return View(air_conditioner);
        }

        // POST: air_conditioner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            air_conditioner air_conditioner = db.air_conditioner.Find(id);
            db.air_conditioner.Remove(air_conditioner);
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

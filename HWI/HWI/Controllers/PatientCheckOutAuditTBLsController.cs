using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HWI;

namespace HWI.Controllers
{
    public class PatientCheckOutAuditTBLsController : Controller
    {
        private HWIDBContext db = new HWIDBContext();

        // GET: PatientCheckOutAuditTBLs
        public ActionResult Index()
        {
            return View(db.PatientCheckOutAuditTBLs.ToList());
        }

        // GET: PatientCheckOutAuditTBLs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientCheckOutAuditTBL patientCheckOutAuditTBL = db.PatientCheckOutAuditTBLs.Find(id);
            if (patientCheckOutAuditTBL == null)
            {
                return HttpNotFound();
            }
            return View(patientCheckOutAuditTBL);
        }

        // GET: PatientCheckOutAuditTBLs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PatientCheckOutAuditTBLs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AuditID,Name,SSN,CheckIn,CheckOut,Doctor,Cause,CauseType,PatientStatus")] PatientCheckOutAuditTBL patientCheckOutAuditTBL)
        {
            if (ModelState.IsValid)
            {
                db.PatientCheckOutAuditTBLs.Add(patientCheckOutAuditTBL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(patientCheckOutAuditTBL);
        }

        // GET: PatientCheckOutAuditTBLs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientCheckOutAuditTBL patientCheckOutAuditTBL = db.PatientCheckOutAuditTBLs.Find(id);
            if (patientCheckOutAuditTBL == null)
            {
                return HttpNotFound();
            }
            return View(patientCheckOutAuditTBL);
        }

        // POST: PatientCheckOutAuditTBLs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AuditID,Name,SSN,CheckIn,CheckOut,Doctor,Cause,CauseType,PatientStatus")] PatientCheckOutAuditTBL patientCheckOutAuditTBL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patientCheckOutAuditTBL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patientCheckOutAuditTBL);
        }

        // GET: PatientCheckOutAuditTBLs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientCheckOutAuditTBL patientCheckOutAuditTBL = db.PatientCheckOutAuditTBLs.Find(id);
            if (patientCheckOutAuditTBL == null)
            {
                return HttpNotFound();
            }
            return View(patientCheckOutAuditTBL);
        }

        // POST: PatientCheckOutAuditTBLs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PatientCheckOutAuditTBL patientCheckOutAuditTBL = db.PatientCheckOutAuditTBLs.Find(id);
            db.PatientCheckOutAuditTBLs.Remove(patientCheckOutAuditTBL);
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

﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using THIS_Hospital;

namespace THIS_Hospital.Controllers
{
    public class PatientsController : Controller
    {
        private HospitalDBContext db = new HospitalDBContext();

        // GET: Patients
        public ActionResult Index()
        {
            var _Patient = db._Patient.Include(p => p.Cause).Include(p => p.Room).Include(p => p.Staff);
            return View(_Patient.ToList());
        }

        // GET: Patients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db._Patient.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // GET: Patients/Create
        public ActionResult Create()
        {
            ViewBag.CauseRefID = new SelectList(db._Cause, "CauseID", "CauseName");
            ViewBag.RoomRefID = new SelectList(db.Rooms, "RoomID", "RoomID");
            ViewBag.StaffRefID = new SelectList(db._Staff, "StaffID", "FName");
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatientID,FName,LName,Adress,PhoneNR,SSN,CeckInHospital,StaffRefID,RoomRefID,CauseRefID")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db._Patient.Add(patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CauseRefID = new SelectList(db._Cause, "CauseID", "CauseName", patient.CauseRefID);
            ViewBag.RoomRefID = new SelectList(db.Rooms, "RoomID", "RoomID", patient.RoomRefID);
            ViewBag.StaffRefID = new SelectList(db._Staff, "StaffID", "FName", patient.StaffRefID);
            return View(patient);
        }

        // GET: Patients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db._Patient.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            ViewBag.CauseRefID = new SelectList(db._Cause, "CauseID", "CauseName", patient.CauseRefID);
            ViewBag.RoomRefID = new SelectList(db.Rooms, "RoomID", "RoomID", patient.RoomRefID);
            ViewBag.StaffRefID = new SelectList(db._Staff, "StaffID", "FName", patient.StaffRefID);
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PatientID,FName,LName,Adress,PhoneNR,SSN,CeckInHospital,StaffRefID,RoomRefID,CauseRefID")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CauseRefID = new SelectList(db._Cause, "CauseID", "CauseName", patient.CauseRefID);
            ViewBag.RoomRefID = new SelectList(db.Rooms, "RoomID", "RoomID", patient.RoomRefID);
            ViewBag.StaffRefID = new SelectList(db._Staff, "StaffID", "FName", patient.StaffRefID);
            return View(patient);
        }

        // GET: Patients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db._Patient.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient patient = db._Patient.Find(id);
            db._Patient.Remove(patient);
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

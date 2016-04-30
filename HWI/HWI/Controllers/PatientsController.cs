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
    public class PatientsController : Controller
    {
        private HWIDBContext db = new HWIDBContext();

        // GET: Patients
        public ActionResult Index()
        {
            var persons = db.Patients.Include(p => p._Cause).Include(p => p._Staff).Include(p => p.Room);
            return View(persons.ToList());
        }

        // GET: Patients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Persons.Find(id) as Patient;
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // GET: Patients/Create
        public ActionResult Create()
        {
            ViewBag._CauseRefID = new SelectList(db.Causes, "CauseID", "CauseName");
            ViewBag._StaffRefID = new SelectList(db.Staffs, "PersonID", "Name");
            ViewBag.RoomRefID = new SelectList(db.Rooms, "RoomID", "RoomNr");
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonID,FName,LName,PhoneNR,SSN,CeckInHospital,RoomRefID,_StaffRefID,_CauseRefID")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Persons.Add(patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag._CauseRefID = new SelectList(db.Causes, "CauseID", "CauseName", patient._CauseRefID);
            ViewBag._StaffRefID = new SelectList(db.Staffs, "PersonID", "Name", patient._StaffRefID);
            ViewBag.RoomRefID = new SelectList(db.Rooms, "RoomID", "RoomNr", patient.RoomRefID);
            return View(patient);
        }

        // GET: Patients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Persons.Find(id) as Patient;
            if (patient == null)
            {
                return HttpNotFound();
            }
            ViewBag._CauseRefID = new SelectList(db.Causes, "CauseID", "CauseName", patient._CauseRefID);
            ViewBag._StaffRefID = new SelectList(db.Staffs, "PersonID", "Name", patient._StaffRefID);
            ViewBag.RoomRefID = new SelectList(db.Rooms, "RoomID", "RoomNr", patient.RoomRefID);
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonID,FName,LName,PhoneNR,SSN,CeckInHospital,RoomRefID,_StaffRefID,_CauseRefID")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag._CauseRefID = new SelectList(db.Causes, "CauseID", "CauseName", patient._CauseRefID);
            ViewBag._StaffRefID = new SelectList(db.Staffs, "PersonID", "Name", patient._StaffRefID);
            ViewBag.RoomRefID = new SelectList(db.Rooms, "RoomID", "RoomNr", patient.RoomRefID);
            return View(patient);
        }

        // GET: Patients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Persons.Find(id) as Patient;
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
            Patient patient = db.Persons.Find(id) as Patient;
            db.Persons.Remove(patient);
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

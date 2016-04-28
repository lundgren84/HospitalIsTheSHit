using System;
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
    public class PrescriptionsController : Controller
    {
        private HospitalDBContext db = new HospitalDBContext();

        // GET: Prescriptions
        public ActionResult Index()
        {
            var prescriptions = db.Prescriptions.Include(p => p.Drug).Include(p => p.Patient).Include(p => p.Staff);
            return View(prescriptions.ToList());
        }

        // GET: Prescriptions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prescription prescription = db.Prescriptions.Find(id);
            if (prescription == null)
            {
                return HttpNotFound();
            }
            return View(prescription);
        }

        // GET: Prescriptions/Create
        public ActionResult Create()
        {
            ViewBag.DrugRefID = new SelectList(db.Drugs, "DrugID", "Description");
            ViewBag.PatientRefID = new SelectList(db._Patient, "PatientID", "Name");
            ViewBag.StaffRefID = new SelectList(db._Staff, "StaffID", "Name");
            return View();
        }

        // POST: Prescriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PrescriptionID,Date,Patient,Staff,Drug")] Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                db.Prescriptions.Add(prescription);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DrugRefID = new SelectList(db.Drugs, "DrugID", "Description", prescription.DrugRefID);
            ViewBag.PatientRefID = new SelectList(db._Patient, "PatientID", "Name", prescription.PatientRefID);
            ViewBag.StaffRefID = new SelectList(db._Staff, "StaffID", "Name", prescription.StaffRefID);
            return View(prescription);
        }

        // GET: Prescriptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prescription prescription = db.Prescriptions.Find(id);
            if (prescription == null)
            {
                return HttpNotFound();
            }
            ViewBag.DrugRefID = new SelectList(db.Drugs, "DrugID", "Description", prescription.DrugRefID);
            ViewBag.PatientRefID = new SelectList(db._Patient, "PatientID", "Name", prescription.PatientRefID);
            ViewBag.StaffRefID = new SelectList(db._Staff, "StaffID", "Name", prescription.StaffRefID);
            return View(prescription);
        }

        // POST: Prescriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PrescriptionID,Date,Patient,Staff,Drug")] Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prescription).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DrugRefID = new SelectList(db.Drugs, "DrugID", "Description", prescription.DrugRefID);
            ViewBag.PatientRefID = new SelectList(db._Patient, "PatientID", "Name", prescription.PatientRefID);
            ViewBag.StaffRefID = new SelectList(db._Staff, "StaffID", "Name", prescription.StaffRefID);
            return View(prescription);
        }

        // GET: Prescriptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prescription prescription = db.Prescriptions.Find(id);
            if (prescription == null)
            {
                return HttpNotFound();
            }
            return View(prescription);
        }

        // POST: Prescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prescription prescription = db.Prescriptions.Find(id);
            db.Prescriptions.Remove(prescription);
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

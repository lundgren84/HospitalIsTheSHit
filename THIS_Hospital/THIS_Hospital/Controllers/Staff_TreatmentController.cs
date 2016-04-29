using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using THIS_Hospital;
using THIS_Hospital.Classes.Manny_TO_Manny;

namespace THIS_Hospital.Controllers
{
    public class Staff_TreatmentController : Controller
    {
        private HospitalDBContext db = new HospitalDBContext();

        // GET: Staff_Treatment
        public ActionResult Index()
        {
            var staff_Treatment = db.Staff_Treatment.Include(s => s.Staff).Include(s => s.Treatment);
            return View(staff_Treatment.ToList());
        }

        // GET: Staff_Treatment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff_Treatment staff_Treatment = db.Staff_Treatment.Find(id);
            if (staff_Treatment == null)
            {
                return HttpNotFound();
            }
            return View(staff_Treatment);
        }

        // GET: Staff_Treatment/Create
        public ActionResult Create()
        {
            ViewBag.StaffID = new SelectList(db._Staff, "StaffID", "Name");
            ViewBag.TreatmentID = new SelectList(db._Treatment, "TreatmentID", "TreatmentID");
            return View();
        }

        // POST: Staff_Treatment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StaffID,TreatmentID")] Staff_Treatment staff_Treatment)
        {
            if (ModelState.IsValid)
            {
                db.Staff_Treatment.Add(staff_Treatment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StaffID = new SelectList(db._Staff, "StaffID", "Name", staff_Treatment.StaffID);
            ViewBag.TreatmentID = new SelectList(db._Treatment, "TreatmentID", "TreatmentID", staff_Treatment.TreatmentID);
            return View(staff_Treatment);
        }

        // GET: Staff_Treatment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff_Treatment staff_Treatment = db.Staff_Treatment.Find(id);
            if (staff_Treatment == null)
            {
                return HttpNotFound();
            }
            ViewBag.StaffID = new SelectList(db._Staff, "StaffID", "Name", staff_Treatment.StaffID);
            ViewBag.TreatmentID = new SelectList(db._Treatment, "TreatmentID", "TreatmentID", staff_Treatment.TreatmentID);
            return View(staff_Treatment);
        }

        // POST: Staff_Treatment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StaffID,TreatmentID")] Staff_Treatment staff_Treatment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staff_Treatment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StaffID = new SelectList(db._Staff, "StaffID", "Name", staff_Treatment.StaffID);
            ViewBag.TreatmentID = new SelectList(db._Treatment, "TreatmentID", "TreatmentID", staff_Treatment.TreatmentID);
            return View(staff_Treatment);
        }

        // GET: Staff_Treatment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff_Treatment staff_Treatment = db.Staff_Treatment.Find(id);
            if (staff_Treatment == null)
            {
                return HttpNotFound();
            }
            return View(staff_Treatment);
        }

        // POST: Staff_Treatment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Staff_Treatment staff_Treatment = db.Staff_Treatment.Find(id);
            db.Staff_Treatment.Remove(staff_Treatment);
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

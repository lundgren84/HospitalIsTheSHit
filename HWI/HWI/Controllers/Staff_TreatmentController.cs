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
    public class Staff_TreatmentController : Controller
    {
        private HWIDBContext db = new HWIDBContext();

        // GET: Staff_Treatment
        public ActionResult Index()
        {
            var staffTreatment = db.staffTreatment.Include(s => s._Staff).Include(s => s._Treatment);
            return View(staffTreatment.ToList());
        }

        // GET: Staff_Treatment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff_Treatment staff_Treatment = db.staffTreatment.Find(id);
            if (staff_Treatment == null)
            {
                return HttpNotFound();
            }
            return View(staff_Treatment);
        }

        // GET: Staff_Treatment/Create
        public ActionResult Create()
        {
            ViewBag.PersonID = new SelectList(db.Staffs, "PersonID", "Name");
            ViewBag.TreatmentID = new SelectList(db.Treatments, "TreatmentID", "TreatmentID");
            return View();
        }

        // POST: Staff_Treatment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TreatmentID,PersonID")] Staff_Treatment staff_Treatment)
        {
            if (ModelState.IsValid)
            {
                db.staffTreatment.Add(staff_Treatment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonID = new SelectList(db.Staffs, "PersonID", "Name", staff_Treatment.PersonID);
            ViewBag.TreatmentID = new SelectList(db.Treatments, "TreatmentID", "TreatmentID", staff_Treatment.TreatmentID);
            return View(staff_Treatment);
        }

        // GET: Staff_Treatment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff_Treatment staff_Treatment = db.staffTreatment.Find(id);
            if (staff_Treatment == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonID = new SelectList(db.Staffs, "PersonID", "Name", staff_Treatment.PersonID);
            ViewBag.TreatmentID = new SelectList(db.Treatments, "TreatmentID", "TreatmentID", staff_Treatment.TreatmentID);
            return View(staff_Treatment);
        }

        // POST: Staff_Treatment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TreatmentID,PersonID")] Staff_Treatment staff_Treatment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staff_Treatment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonID = new SelectList(db.Staffs, "PersonID", "Name", staff_Treatment.PersonID);
            ViewBag.TreatmentID = new SelectList(db.Treatments, "TreatmentID", "TreatmentID", staff_Treatment.TreatmentID);
            return View(staff_Treatment);
        }

        // GET: Staff_Treatment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff_Treatment staff_Treatment = db.staffTreatment.Find(id);
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
            Staff_Treatment staff_Treatment = db.staffTreatment.Find(id);
            db.staffTreatment.Remove(staff_Treatment);
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

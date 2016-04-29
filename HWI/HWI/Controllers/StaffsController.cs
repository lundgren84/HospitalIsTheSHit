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
    public class StaffsController : Controller
    {
        private HWIDBContext db = new HWIDBContext();

        // GET: Staffs
        public ActionResult Index()
        {
            var persons = db.Staffs.Include(s => s.Proffesion);
            return View(persons.ToList());
        }

        // GET: Staffs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = db.Persons.Find(id)as Staff;
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // GET: Staffs/Create
        public ActionResult Create()
        {
            ViewBag.ProffesionRefID = new SelectList(db.professions, "ProffesionID", "Profession_Name");
            return View();
        }

        // POST: Staffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonID,FName,LName,PhoneNR,SSN,HireDate,ProffesionRefID")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                db.Persons.Add(staff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProffesionRefID = new SelectList(db.professions, "ProffesionID", "Profession_Name", staff.ProffesionRefID);
            return View(staff);
        }

        // GET: Staffs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = db.Persons.Find(id) as Staff;
            if (staff == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProffesionRefID = new SelectList(db.professions, "ProffesionID", "Profession_Name", staff.ProffesionRefID);
            return View(staff);
        }

        // POST: Staffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonID,FName,LName,PhoneNR,SSN,HireDate,ProffesionRefID")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProffesionRefID = new SelectList(db.professions, "ProffesionID", "Profession_Name", staff.ProffesionRefID);
            return View(staff);
        }

        // GET: Staffs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = db.Persons.Find(id) as Staff;
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // POST: Staffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Staff staff = db.Persons.Find(id) as Staff;
            db.Persons.Remove(staff);
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

﻿using System;
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
    public class TreatmentStatusController : Controller
    {
        private HWIDBContext db = new HWIDBContext();

        // GET: TreatmentStatus
        public ActionResult Index()
        {
            return View(db.TreatmentStatus.ToList());
        }

        // GET: TreatmentStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TreatmentStatus treatmentStatus = db.TreatmentStatus.Find(id);
            if (treatmentStatus == null)
            {
                return HttpNotFound();
            }
            return View(treatmentStatus);
        }

        // GET: TreatmentStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TreatmentStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TreatmentStatusID,Status")] TreatmentStatus treatmentStatus)
        {
            if (ModelState.IsValid)
            {
                db.TreatmentStatus.Add(treatmentStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(treatmentStatus);
        }

        // GET: TreatmentStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TreatmentStatus treatmentStatus = db.TreatmentStatus.Find(id);
            if (treatmentStatus == null)
            {
                return HttpNotFound();
            }
            return View(treatmentStatus);
        }

        // POST: TreatmentStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TreatmentStatusID,Status")] TreatmentStatus treatmentStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(treatmentStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(treatmentStatus);
        }

        // GET: TreatmentStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TreatmentStatus treatmentStatus = db.TreatmentStatus.Find(id);
            if (treatmentStatus == null)
            {
                return HttpNotFound();
            }
            return View(treatmentStatus);
        }

        // POST: TreatmentStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TreatmentStatus treatmentStatus = db.TreatmentStatus.Find(id);
            db.TreatmentStatus.Remove(treatmentStatus);
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

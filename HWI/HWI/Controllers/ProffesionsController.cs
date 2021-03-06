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
    public class ProffesionsController : Controller
    {
        private HWIDBContext db = new HWIDBContext();

        // GET: Proffesions
        public ActionResult Index()
        {
            return View(db.professions.ToList());
        }

        // GET: Proffesions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proffesion proffesion = db.professions.Find(id);
            if (proffesion == null)
            {
                return HttpNotFound();
            }
            return View(proffesion);
        }

        // GET: Proffesions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proffesions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProffesionID,Profession_Name")] Proffesion proffesion)
        {
            if (ModelState.IsValid)
            {
                db.professions.Add(proffesion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(proffesion);
        }

        // GET: Proffesions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proffesion proffesion = db.professions.Find(id);
            if (proffesion == null)
            {
                return HttpNotFound();
            }
            return View(proffesion);
        }

        // POST: Proffesions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProffesionID,Profession_Name")] Proffesion proffesion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proffesion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proffesion);
        }

        // GET: Proffesions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proffesion proffesion = db.professions.Find(id);
            if (proffesion == null)
            {
                return HttpNotFound();
            }
            return View(proffesion);
        }

        // POST: Proffesions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proffesion proffesion = db.professions.Find(id);
            db.professions.Remove(proffesion);
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

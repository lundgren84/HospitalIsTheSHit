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
    public class WhatsDonesController : Controller
    {
        private HWIDBContext db = new HWIDBContext();

        // GET: WhatsDones
        public ActionResult Index()
        {
            return View(db.WhatsDones.ToList());
        }

        // GET: WhatsDones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WhatsDone whatsDone = db.WhatsDones.Find(id);
            if (whatsDone == null)
            {
                return HttpNotFound();
            }
            return View(whatsDone);
        }

        // GET: WhatsDones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WhatsDones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WhatsDoneID,Description")] WhatsDone whatsDone)
        {
            if (ModelState.IsValid)
            {
                db.WhatsDones.Add(whatsDone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(whatsDone);
        }

        // GET: WhatsDones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WhatsDone whatsDone = db.WhatsDones.Find(id);
            if (whatsDone == null)
            {
                return HttpNotFound();
            }
            return View(whatsDone);
        }

        // POST: WhatsDones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WhatsDoneID,Description")] WhatsDone whatsDone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(whatsDone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(whatsDone);
        }

        // GET: WhatsDones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WhatsDone whatsDone = db.WhatsDones.Find(id);
            if (whatsDone == null)
            {
                return HttpNotFound();
            }
            return View(whatsDone);
        }

        // POST: WhatsDones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WhatsDone whatsDone = db.WhatsDones.Find(id);
            db.WhatsDones.Remove(whatsDone);
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

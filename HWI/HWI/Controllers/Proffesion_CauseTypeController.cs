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
    public class Proffesion_CauseTypeController : Controller
    {
        private HWIDBContext db = new HWIDBContext();

        // GET: Proffesion_CauseType
        public ActionResult Index()
        {
            var proffesion_CauseType = db.Proffesion_CauseType.Include(p => p.CauseType).Include(p => p.Proffesion);
            return View(proffesion_CauseType.ToList());
        }

        // GET: Proffesion_CauseType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proffesion_CauseType proffesion_CauseType = db.Proffesion_CauseType.Find(id);
            if (proffesion_CauseType == null)
            {
                return HttpNotFound();
            }
            return View(proffesion_CauseType);
        }

        // GET: Proffesion_CauseType/Create
        public ActionResult Create()
        {
            ViewBag.CauseTypeID = new SelectList(db.CauseTypes, "CauseTypeID", "CauseTypeName");
            ViewBag.ProffesionID = new SelectList(db.professions, "ProffesionID", "Profession_Name");
            return View();
        }

        // POST: Proffesion_CauseType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProffesionID,CauseTypeID")] Proffesion_CauseType proffesion_CauseType)
        {
            if (ModelState.IsValid)
            {
                db.Proffesion_CauseType.Add(proffesion_CauseType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CauseTypeID = new SelectList(db.CauseTypes, "CauseTypeID", "CauseTypeName", proffesion_CauseType.CauseTypeID);
            ViewBag.ProffesionID = new SelectList(db.professions, "ProffesionID", "Profession_Name", proffesion_CauseType.ProffesionID);
            return View(proffesion_CauseType);
        }

        // GET: Proffesion_CauseType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proffesion_CauseType proffesion_CauseType = db.Proffesion_CauseType.Find(id);
            if (proffesion_CauseType == null)
            {
                return HttpNotFound();
            }
            ViewBag.CauseTypeID = new SelectList(db.CauseTypes, "CauseTypeID", "CauseTypeName", proffesion_CauseType.CauseTypeID);
            ViewBag.ProffesionID = new SelectList(db.professions, "ProffesionID", "Profession_Name", proffesion_CauseType.ProffesionID);
            return View(proffesion_CauseType);
        }

        // POST: Proffesion_CauseType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProffesionID,CauseTypeID")] Proffesion_CauseType proffesion_CauseType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proffesion_CauseType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CauseTypeID = new SelectList(db.CauseTypes, "CauseTypeID", "CauseTypeName", proffesion_CauseType.CauseTypeID);
            ViewBag.ProffesionID = new SelectList(db.professions, "ProffesionID", "Profession_Name", proffesion_CauseType.ProffesionID);
            return View(proffesion_CauseType);
        }

        // GET: Proffesion_CauseType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proffesion_CauseType proffesion_CauseType = db.Proffesion_CauseType.Find(id);
            if (proffesion_CauseType == null)
            {
                return HttpNotFound();
            }
            return View(proffesion_CauseType);
        }

        // POST: Proffesion_CauseType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proffesion_CauseType proffesion_CauseType = db.Proffesion_CauseType.Find(id);
            db.Proffesion_CauseType.Remove(proffesion_CauseType);
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

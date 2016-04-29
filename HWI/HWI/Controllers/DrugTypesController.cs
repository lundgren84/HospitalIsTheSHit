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
    public class DrugTypesController : Controller
    {
        private HWIDBContext db = new HWIDBContext();

        // GET: DrugTypes
        public ActionResult Index()
        {
            return View(db.DrugTypes.ToList());
        }

        // GET: DrugTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrugType drugType = db.DrugTypes.Find(id);
            if (drugType == null)
            {
                return HttpNotFound();
            }
            return View(drugType);
        }

        // GET: DrugTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DrugTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DrugTypeID,Desecription")] DrugType drugType)
        {
            if (ModelState.IsValid)
            {
                db.DrugTypes.Add(drugType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(drugType);
        }

        // GET: DrugTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrugType drugType = db.DrugTypes.Find(id);
            if (drugType == null)
            {
                return HttpNotFound();
            }
            return View(drugType);
        }

        // POST: DrugTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DrugTypeID,Desecription")] DrugType drugType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drugType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(drugType);
        }

        // GET: DrugTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrugType drugType = db.DrugTypes.Find(id);
            if (drugType == null)
            {
                return HttpNotFound();
            }
            return View(drugType);
        }

        // POST: DrugTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DrugType drugType = db.DrugTypes.Find(id);
            db.DrugTypes.Remove(drugType);
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

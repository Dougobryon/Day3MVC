using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Day3MVC.Models;

namespace Day3MVC.Controllers
{
    public class PropertyModelsController : Controller
    {
        private Day3MVCContext db = new Day3MVCContext();

        // GET: PropertyModels
        public ActionResult Index()
        {
            return View(db.PropertyModels.ToList());
        }

        // GET: PropertyModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyModels propertyModels = db.PropertyModels.Find(id);
            if (propertyModels == null)
            {
                return HttpNotFound();
            }
            return View(propertyModels);
        }

        // GET: PropertyModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PropertyModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PropertyId,Title,Description,ImageSource")] PropertyModels propertyModels)
        {
            if (ModelState.IsValid)
            {
                db.PropertyModels.Add(propertyModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(propertyModels);
        }

        // GET: PropertyModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyModels propertyModels = db.PropertyModels.Find(id);
            if (propertyModels == null)
            {
                return HttpNotFound();
            }
            return View(propertyModels);
        }

        // POST: PropertyModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PropertyId,Title,Description,ImageSource")] PropertyModels propertyModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(propertyModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(propertyModels);
        }

        // GET: PropertyModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyModels propertyModels = db.PropertyModels.Find(id);
            if (propertyModels == null)
            {
                return HttpNotFound();
            }
            return View(propertyModels);
        }

        // POST: PropertyModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PropertyModels propertyModels = db.PropertyModels.Find(id);
            db.PropertyModels.Remove(propertyModels);
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

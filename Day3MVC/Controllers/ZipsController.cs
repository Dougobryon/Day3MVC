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
    public class ZipsController : Controller
    {
        private Day3MVCContext db = new Day3MVCContext();

        // GET: Zips
        public ActionResult Index()
        {
            return View(db.Zips.ToList());
        }

        // GET: Zips/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zips zips = db.Zips.Find(id);
            if (zips == null)
            {
                return HttpNotFound();
            }
            return View(zips);
        }

        // GET: Zips/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Zips/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ZipId,ZipCode")] Zips zips)
        {
            if (ModelState.IsValid)
            {
                db.Zips.Add(zips);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zips);
        }

        // GET: Zips/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zips zips = db.Zips.Find(id);
            if (zips == null)
            {
                return HttpNotFound();
            }
            return View(zips);
        }

        // POST: Zips/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ZipId,ZipCode")] Zips zips)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zips).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zips);
        }

        // GET: Zips/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zips zips = db.Zips.Find(id);
            if (zips == null)
            {
                return HttpNotFound();
            }
            return View(zips);
        }

        // POST: Zips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zips zips = db.Zips.Find(id);
            db.Zips.Remove(zips);
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

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
    public class ZipToCitiesController : Controller
    {
        private Day3MVCContext db = new Day3MVCContext();

        // GET: ZipToCities
        public ActionResult Index()
        {
            var zipToCities = db.ZipToCities.Include(z => z.City).Include(z => z.Zip);
            return View(zipToCities.ToList());
        }

        // GET: ZipToCities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZipToCities zipToCities = db.ZipToCities.Find(id);
            if (zipToCities == null)
            {
                return HttpNotFound();
            }
            return View(zipToCities);
        }

        // GET: ZipToCities/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName");
            ViewBag.ZipId = new SelectList(db.Zips, "ZipId", "ZipCode");
            return View();
        }

        // POST: ZipToCities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ZToC,CityId,ZipId")] ZipToCities zipToCities)
        {
            if (ModelState.IsValid)
            {
                db.ZipToCities.Add(zipToCities);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName", zipToCities.CityId);
            ViewBag.ZipId = new SelectList(db.Zips, "ZipId", "ZipCode", zipToCities.ZipId);
            return View(zipToCities);
        }

        // GET: ZipToCities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZipToCities zipToCities = db.ZipToCities.Find(id);
            if (zipToCities == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName", zipToCities.CityId);
            ViewBag.ZipId = new SelectList(db.Zips, "ZipId", "ZipCode", zipToCities.ZipId);
            return View(zipToCities);
        }

        // POST: ZipToCities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ZToC,CityId,ZipId")] ZipToCities zipToCities)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zipToCities).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName", zipToCities.CityId);
            ViewBag.ZipId = new SelectList(db.Zips, "ZipId", "ZipCode", zipToCities.ZipId);
            return View(zipToCities);
        }

        // GET: ZipToCities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ZipToCities zipToCities = db.ZipToCities.Find(id);
            if (zipToCities == null)
            {
                return HttpNotFound();
            }
            return View(zipToCities);
        }

        // POST: ZipToCities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ZipToCities zipToCities = db.ZipToCities.Find(id);
            db.ZipToCities.Remove(zipToCities);
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

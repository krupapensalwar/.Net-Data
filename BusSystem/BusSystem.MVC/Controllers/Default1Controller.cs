using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusSystem.Core;

namespace BusSystem.MVC
{
    public class Default1Controller : Controller
    {
        private BusReservationSystemDBEntities db = new BusReservationSystemDBEntities();

        // GET: /Default1/
        public ActionResult Index()
        {
            var businfoes = db.BusInfoes.Include(b => b.CategoryInfo);
            return View(businfoes.ToList());
        }

        // GET: /Default1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusInfo businfo = db.BusInfoes.Find(id);
            if (businfo == null)
            {
                return HttpNotFound();
            }
            return View(businfo);
        }

        // GET: /Default1/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.CategoryInfoes, "CategoryId", "CategoryName");
            return View();
        }

        // POST: /Default1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="BusId,BusName,TotalSeats,CategoryId")] BusInfo businfo)
        {
            if (ModelState.IsValid)
            {
                db.BusInfoes.Add(businfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.CategoryInfoes, "CategoryId", "CategoryName", businfo.CategoryId);
            return View(businfo);
        }

        // GET: /Default1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusInfo businfo = db.BusInfoes.Find(id);
            if (businfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.CategoryInfoes, "CategoryId", "CategoryName", businfo.CategoryId);
            return View(businfo);
        }

        // POST: /Default1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="BusId,BusName,TotalSeats,CategoryId")] BusInfo businfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(businfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.CategoryInfoes, "CategoryId", "CategoryName", businfo.CategoryId);
            return View(businfo);
        }

        // GET: /Default1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusInfo businfo = db.BusInfoes.Find(id);
            if (businfo == null)
            {
                return HttpNotFound();
            }
            return View(businfo);
        }

        // POST: /Default1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BusInfo businfo = db.BusInfoes.Find(id);
            db.BusInfoes.Remove(businfo);
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

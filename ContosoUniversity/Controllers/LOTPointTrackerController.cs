using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ContosoUniversity.DAL;
using ContosoUniversity.Models;

namespace ContosoUniversity.Controllers
{
    public class LOTPointTrackerController : Controller
    {
        private SchoolContext db = new SchoolContext();

        // GET: LOTPointTracker
        public ActionResult Index()
        {
            return View(db.PointTracker.ToList());
        }

        // GET: LOTPointTracker/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOTPointTracker lOTPointTracker = db.PointTracker.Find(id);
            if (lOTPointTracker == null)
            {
                return HttpNotFound();
            }
            return View(lOTPointTracker);
        }

        // GET: LOTPointTracker/Create
        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "ID", "FullName");
            return View();
        }

        // POST: LOTPointTracker/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LOTPointTrackerID,StudentID,LOTMeetingDate,AttendanceConfirmed,OnTimeConfirmed,CurrentEventsConfirmed,ParticipationConfirmed,OutsideEventConfirmed,BinderConfirmed")] LOTPointTracker lOTPointTracker)
        {
            if (ModelState.IsValid)
            {
                db.PointTracker.Add(lOTPointTracker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lOTPointTracker);
        }

        // GET: LOTPointTracker/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOTPointTracker lOTPointTracker = db.PointTracker.Find(id);
            if (lOTPointTracker == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "ID", "FullName", lOTPointTracker.StudentID);
            return View(lOTPointTracker);
        }

        // POST: LOTPointTracker/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LOTPointTrackerID,LOTMeetingDate,AttendanceConfirmed,OnTimeConfirmed,CurrentEventsConfirmed,ParticipationConfirmed,OutsideEventConfirmed,BinderConfirmed,StudentID")] LOTPointTracker lOTPointTracker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOTPointTracker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lOTPointTracker);
        }

        // GET: LOTPointTracker/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOTPointTracker lOTPointTracker = db.PointTracker.Find(id);
            if (lOTPointTracker == null)
            {
                return HttpNotFound();
            }
            return View(lOTPointTracker);
        }

        // POST: LOTPointTracker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LOTPointTracker lOTPointTracker = db.PointTracker.Find(id);
            db.PointTracker.Remove(lOTPointTracker);
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

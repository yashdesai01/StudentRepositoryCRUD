using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Student.Database;

namespace Student.Web.Controllers
{
    public class StudentDetailsController : Controller
    {
        private StudentDBEntities db = new StudentDBEntities();

        public ActionResult Index()
        {
            var studentDetails = db.tblStudentDetails;
            return View(studentDetails.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStudentDetail studentDetail = db.tblStudentDetails.Find(id);
            if (studentDetail == null)
            {
                return HttpNotFound();
            }
            return View(studentDetail);
        }

        public ActionResult Create()
        {
            ViewBag.Status = new SelectList(db.tblStudentDetails, "StatusID", "StatusName");
            ViewBag.State = new SelectList(db.Status, "StateID", "StateName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,Name,Status,State,ImagePath,Country")] tblStudentDetail studentDetail)
        {
            if (ModelState.IsValid)
            {
                db.tblStudentDetails.Add(studentDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Status = new SelectList(db.tblStudentDetails, "StatusID", "StatusName", studentDetail.Status);
            ViewBag.State = new SelectList(db.Status, "StateID", "StateName", studentDetail.Status);
            return View(studentDetail);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStudentDetail studentDetail = db.tblStudentDetails.Find(id);
            if (studentDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.Status = new SelectList(db.Status, "StatusID", "StatusName", studentDetail.Status);
            ViewBag.State = new SelectList(db.countryStates, "StateID", "StateName", studentDetail.Status);
            return View(studentDetail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,Name,Status,State,ImagePath,Country")] tblStudentDetail studentDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Status = new SelectList(db.Status, "StatusID", "StatusName", studentDetail.Status);
            ViewBag.State = new SelectList(db.countryStates, "StateID", "StateName", studentDetail.Status);
            return View(studentDetail);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStudentDetail studentDetail = db.tblStudentDetails.Find(id);
            if (studentDetail == null)
            {
                return HttpNotFound();
            }
            return View(studentDetail);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblStudentDetail studentDetail = db.tblStudentDetails.Find(id);
            db.tblStudentDetails.Remove(studentDetail);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lab5.Models;

namespace Lab5.Controllers
{
    public class Student_DATAController : Controller
    {
        private Lab5Entities db = new Lab5Entities();

        // GET: Student_DATA
        public ActionResult Index()
        {
            return View(db.Student_DATA.ToList());
        }

        // GET: Student_DATA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_DATA student_DATA = db.Student_DATA.Find(id);
            if (student_DATA == null)
            {
                return HttpNotFound();
            }
            return View(student_DATA);
        }

        // GET: Student_DATA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student_DATA/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,first_name,last_name,email,gender,ip_address")] Student_DATA student_DATA)
        {
            if (ModelState.IsValid)
            {
                db.Student_DATA.Add(student_DATA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student_DATA);
        }

        // GET: Student_DATA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_DATA student_DATA = db.Student_DATA.Find(id);
            if (student_DATA == null)
            {
                return HttpNotFound();
            }
            return View(student_DATA);
        }

        // POST: Student_DATA/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,first_name,last_name,email,gender,ip_address")] Student_DATA student_DATA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student_DATA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student_DATA);
        }

        // GET: Student_DATA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_DATA student_DATA = db.Student_DATA.Find(id);
            if (student_DATA == null)
            {
                return HttpNotFound();
            }
            return View(student_DATA);
        }

        // POST: Student_DATA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student_DATA student_DATA = db.Student_DATA.Find(id);
            db.Student_DATA.Remove(student_DATA);
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

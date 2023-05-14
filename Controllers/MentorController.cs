using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eLearning.DAL;
using eLearning.Models;

namespace eLearning.Controllers
{
    public class MentorController : Controller
    {
        private eLearningContext db = new eLearningContext();

        // GET: Mentor
        public ActionResult Index()
        {
            return View(db.Mentors.ToList());
        }

        // GET: Mentor/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mentor mentor = db.Mentors.Find(id);
            if (mentor == null)
            {
                return HttpNotFound();
            }
            return View(mentor);
        }

        // GET: Mentor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mentor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MentorId,NumeMentor,PrenumeMentor,Nivel,Email,Telefon,Descriere")] Mentor mentor)
        {
            if (ModelState.IsValid)
            {
                mentor.MentorId = Guid.NewGuid();
                db.Mentors.Add(mentor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mentor);
        }

        // GET: Mentor/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mentor mentor = db.Mentors.Find(id);
            if (mentor == null)
            {
                return HttpNotFound();
            }
            return View(mentor);
        }

        // POST: Mentor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MentorId,NumeMentor,PrenumeMentor,Nivel,Email,Telefon,Descriere")] Mentor mentor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mentor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mentor);
        }

        // GET: Mentor/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mentor mentor = db.Mentors.Find(id);
            if (mentor == null)
            {
                return HttpNotFound();
            }
            return View(mentor);
        }

        // POST: Mentor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Mentor mentor = db.Mentors.Find(id);
            db.Mentors.Remove(mentor);
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

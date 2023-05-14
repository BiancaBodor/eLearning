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
    public class ResurseController : Controller
    {
        private eLearningContext db = new eLearningContext();

        // GET: Resurse
        public ActionResult Index()
        {
            return View(db.Resurses.ToList());
        }

        // GET: Resurse/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resurse resurse = db.Resurses.Find(id);
            if (resurse == null)
            {
                return HttpNotFound();
            }
            return View(resurse);
        }

        // GET: Resurse/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Resurse/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResurseId,Subiect,Continut,Comentarii")] Resurse resurse)
        {
            if (ModelState.IsValid)
            {
                resurse.ResurseId = Guid.NewGuid();
                db.Resurses.Add(resurse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resurse);
        }

        // GET: Resurse/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resurse resurse = db.Resurses.Find(id);
            if (resurse == null)
            {
                return HttpNotFound();
            }
            return View(resurse);
        }

        // POST: Resurse/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResurseId,Subiect,Continut,Comentarii")] Resurse resurse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resurse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resurse);
        }

        // GET: Resurse/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resurse resurse = db.Resurses.Find(id);
            if (resurse == null)
            {
                return HttpNotFound();
            }
            return View(resurse);
        }

        // POST: Resurse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Resurse resurse = db.Resurses.Find(id);
            db.Resurses.Remove(resurse);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArmyHammerProject.Models;

namespace ArmyHammerProject.Controllers
{
    public class ObjectesMinisController : Controller
    {
        private ArmyContext db = new ArmyContext();

        // GET: ObjectesMinis
        public ActionResult Index()
        {
            var objectesMinis = db.ObjectesMinis.Include(o => o.Miniatura).Include(o => o.Objecte);
            return View(objectesMinis.ToList());
        }

        // GET: ObjectesMinis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObjectesMini objectesMini = db.ObjectesMinis.Find(id);
            if (objectesMini == null)
            {
                return HttpNotFound();
            }
            return View(objectesMini);
        }

        // GET: ObjectesMinis/Create
        public ActionResult Create()
        {
            ViewBag.MiniaturaID = new SelectList(db.Miniatures, "ID", "Nom");
            ViewBag.ObjecteID = new SelectList(db.Objectes, "ID", "Nom");
            return View();
        }

        // POST: ObjectesMinis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MiniaturaID,ObjecteID")] ObjectesMini objectesMini)
        {
            if (ModelState.IsValid)
            {
                db.ObjectesMinis.Add(objectesMini);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MiniaturaID = new SelectList(db.Miniatures, "ID", "Nom", objectesMini.MiniaturaID);
            ViewBag.ObjecteID = new SelectList(db.Objectes, "ID", "Nom", objectesMini.ObjecteID);
            return View(objectesMini);
        }

        // GET: ObjectesMinis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObjectesMini objectesMini = db.ObjectesMinis.Find(id);
            if (objectesMini == null)
            {
                return HttpNotFound();
            }
            ViewBag.MiniaturaID = new SelectList(db.Miniatures, "ID", "Nom", objectesMini.MiniaturaID);
            ViewBag.ObjecteID = new SelectList(db.Objectes, "ID", "Nom", objectesMini.ObjecteID);
            return View(objectesMini);
        }

        // POST: ObjectesMinis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MiniaturaID,ObjecteID")] ObjectesMini objectesMini)
        {
            if (ModelState.IsValid)
            {
                db.Entry(objectesMini).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MiniaturaID = new SelectList(db.Miniatures, "ID", "Nom", objectesMini.MiniaturaID);
            ViewBag.ObjecteID = new SelectList(db.Objectes, "ID", "Nom", objectesMini.ObjecteID);
            return View(objectesMini);
        }

        // GET: ObjectesMinis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ObjectesMini objectesMini = db.ObjectesMinis.Find(id);
            if (objectesMini == null)
            {
                return HttpNotFound();
            }
            return View(objectesMini);
        }

        // POST: ObjectesMinis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ObjectesMini objectesMini = db.ObjectesMinis.Find(id);
            db.ObjectesMinis.Remove(objectesMini);
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

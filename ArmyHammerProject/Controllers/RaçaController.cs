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
    public class RaçaController : Controller
    {
        private ArmyContext db = new ArmyContext();

        // GET: Raça
        public ActionResult Index()
        {
            return View(db.Races.ToList());
        }

        // GET: Raça/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raça raça = db.Races.Find(id);
            if (raça == null)
            {
                return HttpNotFound();
            }
            return View(raça);
        }

        // GET: Raça/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Raça/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nom,Informacio")] Raça raça)
        {
            if (ModelState.IsValid)
            {
                db.Races.Add(raça);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(raça);
        }

        // GET: Raça/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raça raça = db.Races.Find(id);
            if (raça == null)
            {
                return HttpNotFound();
            }
            return View(raça);
        }

        // POST: Raça/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nom,Informacio")] Raça raça)
        {
            if (ModelState.IsValid)
            {
                db.Entry(raça).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(raça);
        }

        // GET: Raça/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Raça raça = db.Races.Find(id);
            if (raça == null)
            {
                return HttpNotFound();
            }
            return View(raça);
        }

        // POST: Raça/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Raça raça = db.Races.Find(id);
            db.Races.Remove(raça);
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

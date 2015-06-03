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
    public class ObjectesController : Controller
    {
        private ArmyContext db = new ArmyContext();

        // GET: Objectes
        public ActionResult Index()
        {
            return View(db.Objectes.ToList());
        }

        // GET: Objectes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objecte objecte = db.Objectes.Find(id);
            if (objecte == null)
            {
                return HttpNotFound();
            }
            return View(objecte);
        }

        // GET: Objectes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Objectes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nom,Moviment,HabilitatArmes,HabilitatProjectils,Força,Resistencia,Ferides,Iniciativa,Atac,Lideratge,SalvacioArmadura,SalvacioEspecial,Regen,BonusTotal")] Objecte objecte)
        {
            if (ModelState.IsValid)
            {
                db.Objectes.Add(objecte);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(objecte);
        }

        // GET: Objectes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objecte objecte = db.Objectes.Find(id);
            if (objecte == null)
            {
                return HttpNotFound();
            }
            return View(objecte);
        }

        // POST: Objectes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nom,Moviment,HabilitatArmes,HabilitatProjectils,Força,Resistencia,Ferides,Iniciativa,Atac,Lideratge,SalvacioArmadura,SalvacioEspecial,Regen,BonusTotal")] Objecte objecte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(objecte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objecte);
        }

        // GET: Objectes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objecte objecte = db.Objectes.Find(id);
            if (objecte == null)
            {
                return HttpNotFound();
            }
            return View(objecte);
        }

        // POST: Objectes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Objecte objecte = db.Objectes.Find(id);
            db.Objectes.Remove(objecte);
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

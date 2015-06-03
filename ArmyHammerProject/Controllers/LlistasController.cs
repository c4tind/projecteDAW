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
    public class LlistasController : Controller
    {
        private ArmyContext db = new ArmyContext();

        // GET: Llistas
        public ActionResult Index()
        {
            var llistes = db.Llistes.Include(l => l.Raça).Include(l => l.Usuari);
            return View(llistes.ToList());
        }

        // GET: Llistas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Llista llista = db.Llistes.Find(id);
            if (llista == null)
            {
                return HttpNotFound();
            }
            return View(llista);
        }

        // GET: Llistas/Create
        public ActionResult Create()
        {
            ViewBag.RaçaID = new SelectList(db.Races, "ID", "Nom");
            ViewBag.UsuariID = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Llistas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nom,Punts,UsuariID,RaçaID")] Llista llista)
        {
            if (ModelState.IsValid)
            {
                db.Llistes.Add(llista);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RaçaID = new SelectList(db.Races, "ID", "Nom", llista.RaçaID);
            ViewBag.UsuariID = new SelectList(db.ApplicationUsers, "Id", "Email", llista.UsuariID);
            return View(llista);
        }

        // GET: Llistas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Llista llista = db.Llistes.Find(id);
            if (llista == null)
            {
                return HttpNotFound();
            }
            ViewBag.RaçaID = new SelectList(db.Races, "ID", "Nom", llista.RaçaID);
            ViewBag.UsuariID = new SelectList(db.Users, "Id", "Email", llista.UsuariID);
            return View(llista);
        }

        // POST: Llistas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nom,Punts,UsuariID,RaçaID")] Llista llista)
        {
            if (ModelState.IsValid)
            {
                db.Entry(llista).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RaçaID = new SelectList(db.Races, "ID", "Nom", llista.RaçaID);
            ViewBag.UsuariID = new SelectList(db.ApplicationUsers, "Id", "Email", llista.UsuariID);
            return View(llista);
        }

        // GET: Llistas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Llista llista = db.Llistes.Find(id);
            if (llista == null)
            {
                return HttpNotFound();
            }
            return View(llista);
        }

        // POST: Llistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Llista llista = db.Llistes.Find(id);
            db.Llistes.Remove(llista);
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

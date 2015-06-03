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
    public class MinisPerLlistasController : Controller
    {
        private ArmyContext db = new ArmyContext();

        // GET: MinisPerLlistas
        public ActionResult Index()
        {
            var minisPerLlistes = db.MinisPerLlistes.Include(m => m.Llista).Include(m => m.Miniatura);
            return View(minisPerLlistes.ToList());
        }

        // GET: MinisPerLlistas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MinisPerLlista minisPerLlista = db.MinisPerLlistes.Find(id);
            if (minisPerLlista == null)
            {
                return HttpNotFound();
            }
            return View(minisPerLlista);
        }

        // GET: MinisPerLlistas/Create
        public ActionResult Create()
        {
            ViewBag.LlistaID = new SelectList(db.Llistes, "ID", "Nom");
            ViewBag.MiniaturaID = new SelectList(db.Miniatures, "ID", "Nom");
            return View();
        }

        // POST: MinisPerLlistas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Quantitat,MiniaturaID,LlistaID")] MinisPerLlista minisPerLlista)
        {
            if (ModelState.IsValid)
            {
                db.MinisPerLlistes.Add(minisPerLlista);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LlistaID = new SelectList(db.Llistes, "ID", "Nom", minisPerLlista.LlistaID);
            ViewBag.MiniaturaID = new SelectList(db.Miniatures, "ID", "Nom", minisPerLlista.MiniaturaID);
            return View(minisPerLlista);
        }

        // GET: MinisPerLlistas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MinisPerLlista minisPerLlista = db.MinisPerLlistes.Find(id);
            if (minisPerLlista == null)
            {
                return HttpNotFound();
            }
            ViewBag.LlistaID = new SelectList(db.Llistes, "ID", "Nom", minisPerLlista.LlistaID);
            ViewBag.MiniaturaID = new SelectList(db.Miniatures, "ID", "Nom", minisPerLlista.MiniaturaID);
            return View(minisPerLlista);
        }

        // POST: MinisPerLlistas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Quantitat,MiniaturaID,LlistaID")] MinisPerLlista minisPerLlista)
        {
            if (ModelState.IsValid)
            {
                db.Entry(minisPerLlista).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LlistaID = new SelectList(db.Llistes, "ID", "Nom", minisPerLlista.LlistaID);
            ViewBag.MiniaturaID = new SelectList(db.Miniatures, "ID", "Nom", minisPerLlista.MiniaturaID);
            return View(minisPerLlista);
        }

        // GET: MinisPerLlistas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MinisPerLlista minisPerLlista = db.MinisPerLlistes.Find(id);
            if (minisPerLlista == null)
            {
                return HttpNotFound();
            }
            return View(minisPerLlista);
        }

        // POST: MinisPerLlistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MinisPerLlista minisPerLlista = db.MinisPerLlistes.Find(id);
            db.MinisPerLlistes.Remove(minisPerLlista);
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

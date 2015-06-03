using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArmyHammerProject.Models;
using ArmyHammerProject.Models;

namespace ArmyHammerProject.Controllers
{
    public class MiniaturasController : Controller
    {
        private ArmyContext db = new ArmyContext();

        // GET: Miniaturas
        public ActionResult Index()
        {
            ApplicationDbInitializer.InitializeIdentityForEF(db);
            var miniatures = db.Miniatures.Include(m => m.Raça);
            return View(miniatures.ToList());
        }

        // GET: Miniaturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Miniatura miniatura = db.Miniatures.Find(id);
            if (miniatura == null)
            {
                return HttpNotFound();
            }
            return View(miniatura);
        }

        // GET: Miniaturas/Create
        public ActionResult Create()
        {
            ViewBag.RaçaID = new SelectList(db.Races, "ID", "Nom");
            return View();
        }

        // POST: Miniaturas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nom,Informacio,Punts,MidaMinima,TipusTropa,Moviment,HabilitatArmes,HabilitatProjectils,Força,Resistencia,Ferides,Iniciativa,Atac,Lideratge,SalvacioArmadura,SalvacioEspecial,Regen,RaçaID")] Miniatura miniatura)
        {
            if (ModelState.IsValid)
            {
                db.Miniatures.Add(miniatura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RaçaID = new SelectList(db.Races, "ID", "Nom", miniatura.RaçaID);
            return View(miniatura);
        }

        // GET: Miniaturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Miniatura miniatura = db.Miniatures.Find(id);
            if (miniatura == null)
            {
                return HttpNotFound();
            }
            ViewBag.RaçaID = new SelectList(db.Races, "ID", "Nom", miniatura.RaçaID);
            return View(miniatura);
        }

        // POST: Miniaturas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nom,Informacio,Punts,MidaMinima,TipusTropa,Moviment,HabilitatArmes,HabilitatProjectils,Força,Resistencia,Ferides,Iniciativa,Atac,Lideratge,SalvacioArmadura,SalvacioEspecial,Regen,RaçaID")] Miniatura miniatura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(miniatura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RaçaID = new SelectList(db.Races, "ID", "Nom", miniatura.RaçaID);
            return View(miniatura);
        }

        // GET: Miniaturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Miniatura miniatura = db.Miniatures.Find(id);
            if (miniatura == null)
            {
                return HttpNotFound();
            }
            return View(miniatura);
        }

        // POST: Miniaturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Miniatura miniatura = db.Miniatures.Find(id);
            db.Miniatures.Remove(miniatura);
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

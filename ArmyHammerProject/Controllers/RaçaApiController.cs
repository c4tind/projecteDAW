using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ArmyHammerProject.Models;

namespace ArmyHammerProject.Controllers
{
    public class RaçaApiController : ApiController
    {
        private ArmyContext db = new ArmyContext();

        // GET: api/RaçaApi
        public IQueryable<Raça> GetRaces()
        {
            return db.Races;
        }

        // GET: api/RaçaApi/5
        [ResponseType(typeof(Raça))]
        public IHttpActionResult GetRaça(int id)
        {
            Raça raça = db.Races.Find(id);
            if (raça == null)
            {
                return NotFound();
            }

            return Ok(raça);
        }

        // PUT: api/RaçaApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRaça(int id, Raça raça)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != raça.ID)
            {
                return BadRequest();
            }

            db.Entry(raça).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RaçaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/RaçaApi
        [ResponseType(typeof(Raça))]
        public IHttpActionResult PostRaça(Raça raça)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Races.Add(raça);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = raça.ID }, raça);
        }

        // DELETE: api/RaçaApi/5
        [ResponseType(typeof(Raça))]
        public IHttpActionResult DeleteRaça(int id)
        {
            Raça raça = db.Races.Find(id);
            if (raça == null)
            {
                return NotFound();
            }

            db.Races.Remove(raça);
            db.SaveChanges();

            return Ok(raça);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RaçaExists(int id)
        {
            return db.Races.Count(e => e.ID == id) > 0;
        }
    }
}
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
using WebApp_FGJE.Models;

namespace WebApp_FGJE.Controllers
{
    public class catDiscriminantesController : ApiController
    {
        private AccessModel db = new AccessModel();

        // GET: api/catDiscriminantes
        public IQueryable<catDiscriminante> GetCatDiscriminantes()
        {
            return db.CatDiscriminantes;
        }

        // GET: api/catDiscriminantes/5
        [ResponseType(typeof(catDiscriminante))]
        public IHttpActionResult GetcatDiscriminante(decimal id)
        {
            catDiscriminante catDiscriminante = db.CatDiscriminantes.Find(id);
            if (catDiscriminante == null)
            {
                return NotFound();
            }

            return Ok(catDiscriminante);
        }

        // PUT: api/catDiscriminantes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutcatDiscriminante(decimal id, catDiscriminante catDiscriminante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != catDiscriminante.catDiscriminante_id)
            {
                return BadRequest();
            }

            db.Entry(catDiscriminante).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!catDiscriminanteExists(id))
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

        // POST: api/catDiscriminantes
        [ResponseType(typeof(catDiscriminante))]
        public IHttpActionResult PostcatDiscriminante(catDiscriminante catDiscriminante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CatDiscriminantes.Add(catDiscriminante);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (catDiscriminanteExists(catDiscriminante.catDiscriminante_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = catDiscriminante.catDiscriminante_id }, catDiscriminante);
        }

        // DELETE: api/catDiscriminantes/5
        [ResponseType(typeof(catDiscriminante))]
        public IHttpActionResult DeletecatDiscriminante(decimal id)
        {
            catDiscriminante catDiscriminante = db.CatDiscriminantes.Find(id);
            if (catDiscriminante == null)
            {
                return NotFound();
            }

            db.CatDiscriminantes.Remove(catDiscriminante);
            db.SaveChanges();

            return Ok(catDiscriminante);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool catDiscriminanteExists(decimal id)
        {
            return db.CatDiscriminantes.Count(e => e.catDiscriminante_id == id) > 0;
        }
    }
}
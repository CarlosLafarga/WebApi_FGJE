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
    public class RolesController : ApiController
    {
        private AccessModel db = new AccessModel();

        // GET: api/Roles
        public IQueryable<Roles> GetRoles()
        {
            return db.Roles;
        }

        // GET: api/Roles/5
        [ResponseType(typeof(Roles))]
        public IHttpActionResult GetRoles(decimal id)
        {
            Roles roles = db.Roles.Find(id);
            if (roles == null)
            {
                return NotFound();
            }

            return Ok(roles);
        }

        // PUT: api/Roles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRoles(decimal id, Roles roles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != roles.Rol_id)
            {
                return BadRequest();
            }

            db.Entry(roles).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolesExists(id))
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

        // POST: api/Roles
        [ResponseType(typeof(Roles))]
        public IHttpActionResult PostRoles(Roles roles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Roles.Add(roles);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RolesExists(roles.Rol_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = roles.Rol_id }, roles);
        }

        // DELETE: api/Roles/5
        [ResponseType(typeof(Roles))]
        public IHttpActionResult DeleteRoles(decimal id)
        {
            Roles roles = db.Roles.Find(id);
            if (roles == null)
            {
                return NotFound();
            }

            db.Roles.Remove(roles);
            db.SaveChanges();

            return Ok(roles);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RolesExists(decimal id)
        {
            return db.Roles.Count(e => e.Rol_id == id) > 0;
        }
    }
}
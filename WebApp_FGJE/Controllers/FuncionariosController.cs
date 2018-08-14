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
    public class FuncionariosController : ApiController
    {
        private AccessModel db = new AccessModel();
      

        // GET: api/Funcionarios
        public IEnumerable<Funcionario> GetFuncionario()
        {

            var action = (from f in db.Funcionario
                          join u in db.Usuario on f.iClaveFuncionario equals u.iClaveFuncionario
                          orderby f.iClaveFuncionario
                          select new
                          {
                              f.iClaveFuncionario,
                              f.cNombreFuncionario,
                              u.cClaveUsuario,
                              f.cApellidoPaternoFuncionario,
                              f.cApellidoMaternoFuncionario,
                              f.dFechaIngreso,
                              u.bEsActivo
                          }).ToList().Select(c => new Funcionario
                          {
                              claveFuncionario = c.iClaveFuncionario,
                              nombre = c.cNombreFuncionario,
                              apPaterno = c.cApellidoPaternoFuncionario,
                              apMaterno = c.cApellidoMaternoFuncionario,
                              fechaIngreso = c.dFechaIngreso,
                              estatus = c.bEsActivo,
                              username = c.cClaveUsuario
                          });

            return action;
        }

        // GET: api/Funcionarios/5

        [ResponseType(typeof(Funcionario))]
        public IHttpActionResult GetFuncionario(decimal id)
        {
            Funcionario funcionario = db.Funcionario.SingleOrDefault( x => x.iClaveFuncionario == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return Ok(funcionario);
        }

        // PUT: api/Funcionarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFuncionario(decimal id, Funcionario funcionario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != funcionario.iClaveFuncionario)
            {
                return BadRequest();
            }

            db.Entry(funcionario).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuncionarioExists(id))
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

        // POST: api/Funcionarios
        [ResponseType(typeof(Funcionario))]
        public IHttpActionResult PostFuncionario(Funcionario funcionario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Funcionario.Add(funcionario);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = funcionario.iClaveFuncionario }, funcionario);
        }

        // DELETE: api/Funcionarios/5
        [ResponseType(typeof(Funcionario))]
        public IHttpActionResult DeleteFuncionario(decimal id)
        {
            Funcionario funcionario = db.Funcionario.Find(id);
            if (funcionario == null)
            {
                return NotFound();
            }

            db.Funcionario.Remove(funcionario);
            db.SaveChanges();

            return Ok(funcionario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FuncionarioExists(decimal id)
        {
            return db.Funcionario.Count(e => e.iClaveFuncionario == id) > 0;
        }
    }
}
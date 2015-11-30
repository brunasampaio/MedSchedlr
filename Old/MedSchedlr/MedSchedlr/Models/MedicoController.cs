using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace MedSchedlr.Models
{
    public class MedicoController : ApiController
    {
        private MEedSchedlrEntities db = new MEedSchedlrEntities();

        // GET: api/Medico
        public IQueryable<Medico> GetMedicos()
        {
            return db.Medicos;
        }

        // GET: api/Medico/5
        [ResponseType(typeof(Medico))]
        public async Task<IHttpActionResult> GetMedico(int id)
        {
            Medico medico = await db.Medicos.FindAsync(id);
            if (medico == null)
            {
                return NotFound();
            }

            return Ok(medico);
        }

        // PUT: api/Medico/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMedico(int id, Medico medico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medico.idMedico)
            {
                return BadRequest();
            }

            db.Entry(medico).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicoExists(id))
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

        // POST: api/Medico
        [ResponseType(typeof(Medico))]
        public async Task<IHttpActionResult> PostMedico(Medico medico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Medicos.Add(medico);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = medico.idMedico }, medico);
        }

        // DELETE: api/Medico/5
        [ResponseType(typeof(Medico))]
        public async Task<IHttpActionResult> DeleteMedico(int id)
        {
            Medico medico = await db.Medicos.FindAsync(id);
            if (medico == null)
            {
                return NotFound();
            }

            db.Medicos.Remove(medico);
            await db.SaveChangesAsync();

            return Ok(medico);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MedicoExists(int id)
        {
            return db.Medicos.Count(e => e.idMedico == id) > 0;
        }
    }
}
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
    public class ConsultorioController : ApiController
    {
        private MEedSchedlrEntities db = new MEedSchedlrEntities();

        // GET: api/Consultorio
        public IQueryable<Consultorio> GetConsultorios()
        {
            return db.Consultorios;
        }

        // GET: api/Consultorio/5
        [ResponseType(typeof(Consultorio))]
        public async Task<IHttpActionResult> GetConsultorio(int id)
        {
            Consultorio consultorio = await db.Consultorios.FindAsync(id);
            if (consultorio == null)
            {
                return NotFound();
            }

            return Ok(consultorio);
        }

        // PUT: api/Consultorio/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutConsultorio(int id, Consultorio consultorio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != consultorio.idConsultorio)
            {
                return BadRequest();
            }

            db.Entry(consultorio).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultorioExists(id))
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

        // POST: api/Consultorio
        [ResponseType(typeof(Consultorio))]
        public async Task<IHttpActionResult> PostConsultorio(Consultorio consultorio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Consultorios.Add(consultorio);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = consultorio.idConsultorio }, consultorio);
        }

        // DELETE: api/Consultorio/5
        [ResponseType(typeof(Consultorio))]
        public async Task<IHttpActionResult> DeleteConsultorio(int id)
        {
            Consultorio consultorio = await db.Consultorios.FindAsync(id);
            if (consultorio == null)
            {
                return NotFound();
            }

            db.Consultorios.Remove(consultorio);
            await db.SaveChangesAsync();

            return Ok(consultorio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConsultorioExists(int id)
        {
            return db.Consultorios.Count(e => e.idConsultorio == id) > 0;
        }
    }
}
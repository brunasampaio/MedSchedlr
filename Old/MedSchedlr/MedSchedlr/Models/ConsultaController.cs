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
    public class ConsultaController : ApiController
    {
        private MEedSchedlrEntities db = new MEedSchedlrEntities();

        // GET: api/Consulta
        public IQueryable<Consulta> GetConsultas()
        {
            return db.Consultas;
        }

        // GET: api/Consulta/5
        [ResponseType(typeof(Consulta))]
        public async Task<IHttpActionResult> GetConsulta(int id)
        {
            Consulta consulta = await db.Consultas.FindAsync(id);
            if (consulta == null)
            {
                return NotFound();
            }

            return Ok(consulta);
        }

        // PUT: api/Consulta/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutConsulta(int id, Consulta consulta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != consulta.idConsulta)
            {
                return BadRequest();
            }

            db.Entry(consulta).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultaExists(id))
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

        // POST: api/Consulta
        [ResponseType(typeof(Consulta))]
        public async Task<IHttpActionResult> PostConsulta(Consulta consulta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Consultas.Add(consulta);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = consulta.idConsulta }, consulta);
        }

        // DELETE: api/Consulta/5
        [ResponseType(typeof(Consulta))]
        public async Task<IHttpActionResult> DeleteConsulta(int id)
        {
            Consulta consulta = await db.Consultas.FindAsync(id);
            if (consulta == null)
            {
                return NotFound();
            }

            db.Consultas.Remove(consulta);
            await db.SaveChangesAsync();

            return Ok(consulta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConsultaExists(int id)
        {
            return db.Consultas.Count(e => e.idConsulta == id) > 0;
        }
    }
}
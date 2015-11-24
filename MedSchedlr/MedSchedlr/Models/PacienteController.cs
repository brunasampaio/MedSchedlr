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
    public class PacienteController : ApiController
    {
        private MEedSchedlrEntities db = new MEedSchedlrEntities();

        // GET: api/Paciente
        public IQueryable<Paciente> GetPacientes()
        {
            return db.Pacientes;
        }

        // GET: api/Paciente/5
        [ResponseType(typeof(Paciente))]
        public async Task<IHttpActionResult> GetPaciente(int id)
        {
            Paciente paciente = await db.Pacientes.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }

            return Ok(paciente);
        }

        // PUT: api/Paciente/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPaciente(int id, Paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paciente.idPaciente)
            {
                return BadRequest();
            }

            db.Entry(paciente).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacienteExists(id))
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

        // POST: api/Paciente
        [ResponseType(typeof(Paciente))]
        public async Task<IHttpActionResult> PostPaciente(Paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pacientes.Add(paciente);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = paciente.idPaciente }, paciente);
        }

        // DELETE: api/Paciente/5
        [ResponseType(typeof(Paciente))]
        public async Task<IHttpActionResult> DeletePaciente(int id)
        {
            Paciente paciente = await db.Pacientes.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }

            db.Pacientes.Remove(paciente);
            await db.SaveChangesAsync();

            return Ok(paciente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PacienteExists(int id)
        {
            return db.Pacientes.Count(e => e.idPaciente == id) > 0;
        }
    }
}
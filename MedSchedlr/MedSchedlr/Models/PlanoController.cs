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
    public class PlanoController : ApiController
    {
        private MEedSchedlrEntities db = new MEedSchedlrEntities();

        // GET: api/Plano
        public IQueryable<Plano> GetPlanoes()
        {
            return db.Planoes;
        }

        // GET: api/Plano/5
        [ResponseType(typeof(Plano))]
        public async Task<IHttpActionResult> GetPlano(int id)
        {
            Plano plano = await db.Planoes.FindAsync(id);
            if (plano == null)
            {
                return NotFound();
            }

            return Ok(plano);
        }

        // PUT: api/Plano/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPlano(int id, Plano plano)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != plano.idPlano)
            {
                return BadRequest();
            }

            db.Entry(plano).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanoExists(id))
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

        // POST: api/Plano
        [ResponseType(typeof(Plano))]
        public async Task<IHttpActionResult> PostPlano(Plano plano)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Planoes.Add(plano);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = plano.idPlano }, plano);
        }

        // DELETE: api/Plano/5
        [ResponseType(typeof(Plano))]
        public async Task<IHttpActionResult> DeletePlano(int id)
        {
            Plano plano = await db.Planoes.FindAsync(id);
            if (plano == null)
            {
                return NotFound();
            }

            db.Planoes.Remove(plano);
            await db.SaveChangesAsync();

            return Ok(plano);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlanoExists(int id)
        {
            return db.Planoes.Count(e => e.idPlano == id) > 0;
        }
    }
}
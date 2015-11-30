using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MedSchedlr.Models
{
    public class PacienteVController : Controller
    {
        private MEedSchedlrEntities db = new MEedSchedlrEntities();

        // GET: PacienteV
        public async Task<ActionResult> Index()
        {
            var pacientes = db.Pacientes.Include(p => p.Plano);
            return View(await pacientes.ToListAsync());
        }

        // GET: PacienteV/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = await db.Pacientes.FindAsync(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // GET: PacienteV/Create
        public ActionResult Create()
        {
            ViewBag.idPlano = new SelectList(db.Planoes, "idPlano", "tipoPlano");
            return View();
        }

        // POST: PacienteV/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idPaciente,nome,endereco,idPlano")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.Pacientes.Add(paciente);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idPlano = new SelectList(db.Planoes, "idPlano", "tipoPlano", paciente.idPlano);
            return View(paciente);
        }

        // GET: PacienteV/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = await db.Pacientes.FindAsync(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPlano = new SelectList(db.Planoes, "idPlano", "tipoPlano", paciente.idPlano);
            return View(paciente);
        }

        // POST: PacienteV/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idPaciente,nome,endereco,idPlano")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paciente).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idPlano = new SelectList(db.Planoes, "idPlano", "tipoPlano", paciente.idPlano);
            return View(paciente);
        }

        // GET: PacienteV/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = await db.Pacientes.FindAsync(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // POST: PacienteV/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Paciente paciente = await db.Pacientes.FindAsync(id);
            db.Pacientes.Remove(paciente);
            await db.SaveChangesAsync();
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

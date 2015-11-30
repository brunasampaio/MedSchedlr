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
    public class ConsultaVController : Controller
    {
        private MEedSchedlrEntities db = new MEedSchedlrEntities();

        // GET: ConsultaV
        public async Task<ActionResult> Index()
        {
            var consultas = db.Consultas.Include(c => c.Medico).Include(c => c.Paciente);
            return View(await consultas.ToListAsync());
        }

        // GET: ConsultaV/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulta consulta = await db.Consultas.FindAsync(id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            return View(consulta);
        }

        // GET: ConsultaV/Create
        public ActionResult Create()
        {
            ViewBag.idMedico = new SelectList(db.Medicos, "idMedico", "especialidade");
            ViewBag.idPaciente = new SelectList(db.Pacientes, "idPaciente", "nome");
            return View();
        }

        // POST: ConsultaV/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idConsulta,idMedico,idPaciente")] Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                db.Consultas.Add(consulta);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idMedico = new SelectList(db.Medicos, "idMedico", "especialidade", consulta.idMedico);
            ViewBag.idPaciente = new SelectList(db.Pacientes, "idPaciente", "nome", consulta.idPaciente);
            return View(consulta);
        }

        // GET: ConsultaV/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulta consulta = await db.Consultas.FindAsync(id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            ViewBag.idMedico = new SelectList(db.Medicos, "idMedico", "especialidade", consulta.idMedico);
            ViewBag.idPaciente = new SelectList(db.Pacientes, "idPaciente", "nome", consulta.idPaciente);
            return View(consulta);
        }

        // POST: ConsultaV/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idConsulta,idMedico,idPaciente")] Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consulta).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idMedico = new SelectList(db.Medicos, "idMedico", "especialidade", consulta.idMedico);
            ViewBag.idPaciente = new SelectList(db.Pacientes, "idPaciente", "nome", consulta.idPaciente);
            return View(consulta);
        }

        // GET: ConsultaV/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulta consulta = await db.Consultas.FindAsync(id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            return View(consulta);
        }

        // POST: ConsultaV/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Consulta consulta = await db.Consultas.FindAsync(id);
            db.Consultas.Remove(consulta);
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

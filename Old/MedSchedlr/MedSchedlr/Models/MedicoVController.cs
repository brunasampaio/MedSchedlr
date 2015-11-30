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
    public class MedicoVController : Controller
    {
        private MEedSchedlrEntities db = new MEedSchedlrEntities();

        // GET: MedicoV
        public async Task<ActionResult> Index()
        {
            var medicos = db.Medicos.Include(m => m.Consultorio);
            return View(await medicos.ToListAsync());
        }

        // GET: MedicoV/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = await db.Medicos.FindAsync(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // GET: MedicoV/Create
        public ActionResult Create()
        {
            ViewBag.idConsultorio = new SelectList(db.Consultorios, "idConsultorio", "endereco");
            return View();
        }

        // POST: MedicoV/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idMedico,especialidade,idConsultorio,crm")] Medico medico)
        {
            if (ModelState.IsValid)
            {
                db.Medicos.Add(medico);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idConsultorio = new SelectList(db.Consultorios, "idConsultorio", "endereco", medico.idConsultorio);
            return View(medico);
        }

        // GET: MedicoV/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = await db.Medicos.FindAsync(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            ViewBag.idConsultorio = new SelectList(db.Consultorios, "idConsultorio", "endereco", medico.idConsultorio);
            return View(medico);
        }

        // POST: MedicoV/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idMedico,especialidade,idConsultorio,crm")] Medico medico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medico).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idConsultorio = new SelectList(db.Consultorios, "idConsultorio", "endereco", medico.idConsultorio);
            return View(medico);
        }

        // GET: MedicoV/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medico medico = await db.Medicos.FindAsync(id);
            if (medico == null)
            {
                return HttpNotFound();
            }
            return View(medico);
        }

        // POST: MedicoV/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Medico medico = await db.Medicos.FindAsync(id);
            db.Medicos.Remove(medico);
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

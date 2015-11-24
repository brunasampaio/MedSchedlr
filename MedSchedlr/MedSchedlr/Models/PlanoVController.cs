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
    public class PlanoVController : Controller
    {
        private MEedSchedlrEntities db = new MEedSchedlrEntities();

        // GET: PlanoV
        public async Task<ActionResult> Index()
        {
            return View(await db.Planoes.ToListAsync());
        }

        // GET: PlanoV/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plano plano = await db.Planoes.FindAsync(id);
            if (plano == null)
            {
                return HttpNotFound();
            }
            return View(plano);
        }

        // GET: PlanoV/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlanoV/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idPlano,tipoPlano,acomodacao")] Plano plano)
        {
            if (ModelState.IsValid)
            {
                db.Planoes.Add(plano);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(plano);
        }

        // GET: PlanoV/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plano plano = await db.Planoes.FindAsync(id);
            if (plano == null)
            {
                return HttpNotFound();
            }
            return View(plano);
        }

        // POST: PlanoV/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idPlano,tipoPlano,acomodacao")] Plano plano)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plano).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(plano);
        }

        // GET: PlanoV/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plano plano = await db.Planoes.FindAsync(id);
            if (plano == null)
            {
                return HttpNotFound();
            }
            return View(plano);
        }

        // POST: PlanoV/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Plano plano = await db.Planoes.FindAsync(id);
            db.Planoes.Remove(plano);
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

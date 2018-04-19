using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Desafio.Models;

namespace Desafio.Controllers
{
    public class ClinicasController : Controller
    {
        private contexto db = new contexto();

        // GET: Clinicas
        public ActionResult Index()
        {
            
            return View(db.Clinica.ToList());
        }

        // GET: Clinicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clinicas clinicas = db.Clinica.Include(m => m.medicos).FirstOrDefault(m => m.ClinicaID.Equals(id.Value));
            if (clinicas == null)
            {
                return HttpNotFound();
            }
            return View(clinicas);
        }

        // GET: Clinicas/Create
        public ActionResult Create()
        {
            var dropMedicos = new List<SelectListItem>();

            foreach (var medico in db.Medicos.Where(o => o.Ativo).ToList())
                dropMedicos.Add(new SelectListItem { Text = medico.Nome, Value = medico.MedicoID.ToString() });

            dropMedicos.Add(new SelectListItem { Text = "Selecione...", Selected = true });

            ViewBag.Medico = dropMedicos;

            return View();
        }
        // POST: Clinicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClinicaID,NomeClinica,IDMedico")] Clinicas clinicas)
        {
            if (ModelState.IsValid)
            {
                db.Clinica.Add(clinicas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clinicas);
        }

        // GET: Clinicas/Edit/5
        public ActionResult Edit(int? id)
        {
            var dropMedicos = new List<SelectListItem>();

            foreach (var medico in db.Medicos.Where(o => o.Ativo).ToList())
                dropMedicos.Add(new SelectListItem { Text = medico.Nome, Value = medico.MedicoID.ToString() });

            dropMedicos.Add(new SelectListItem { Text = "Selecione...", Selected = true });

            ViewBag.Medico = dropMedicos;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clinicas clinicas = db.Clinica.Include(m => m.medicos).FirstOrDefault(m => m.ClinicaID.Equals(id.Value));
            if (clinicas == null)
            {
                return HttpNotFound();
            }
            return View(clinicas);
        }

        // POST: Clinicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClinicaID,NomeClinica,IDMedico")] Clinicas clinicas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clinicas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clinicas);
        }

        // GET: Clinicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clinicas clinicas = db.Clinica.Include(m => m.medicos).FirstOrDefault(m => m.ClinicaID.Equals(id.Value));
            if (clinicas == null)
            {
                return HttpNotFound();
            }
            return View(clinicas);
        }

        // POST: Clinicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clinicas clinicas = db.Clinica.Find(id);
            db.Clinica.Remove(clinicas);
            db.SaveChanges();
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

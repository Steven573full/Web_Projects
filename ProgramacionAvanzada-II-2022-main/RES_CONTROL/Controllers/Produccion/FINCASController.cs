using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc;

using RES_CONTROL.Clases;
using RES_CONTROL.Models;

namespace RES_CONTROL.Controllers.Produccion
{
    public class FINCASController : Controller
    {
        private GANADERAEntities db = new GANADERAEntities();
        private AyudanteFincas ayudante = new AyudanteFincas();

        [Authorize]
        // GET: FINCAS
        public ActionResult Index()
        {
            return View(db.FINCAS.ToList());
        }

        // GET: FINCAS/Details/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FINCAS fINCAS = db.FINCAS.Find(id);
            if (fINCAS == null)
            {
                return HttpNotFound();
            }
            return View(fINCAS);
        }

        // GET: FINCAS/Create
        public ActionResult Crear()
        {
            return View();
        }

        // POST: FINCAS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "ID_FINCA,NOMBRE_FINCA,LOCACION_FINCA")] FINCAS fINCAS)
        {
            if (ModelState.IsValid)
            {
                db.FINCAS.Add(fINCAS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fINCAS);
        }

        // GET: FINCAS/Edit/5
        public ActionResult Modificar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FINCAS fINCAS = db.FINCAS.Find(id);
            if (fINCAS == null)
            {
                return HttpNotFound();
            }
            return View(fINCAS);
        }

        // POST: FINCAS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modificar([Bind(Include = "ID_FINCA,NOMBRE_FINCA,LOCACION_FINCA")] FINCAS fINCAS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fINCAS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fINCAS);
        }

        // GET: FINCAS/Delete/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FINCAS fINCAS = db.FINCAS.Find(id);
            if (fINCAS == null)
            {
                return HttpNotFound();
            }
            return View(fINCAS);
        }

        // POST: FINCAS/Delete/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FINCAS fINCAS = db.FINCAS.Find(id);
            db.FINCAS.Remove(fINCAS);
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

        public ActionResult ReportePorUbicacion(string parte)
        {
            return View(ayudante.ReporteFincaPorUbicacion(parte));
        }

        public ActionResult ReportePotrerosPorFinca(string parte)
        {
            return View(ayudante.ReportePotrerosPorFinca(parte));
        }

    }
}

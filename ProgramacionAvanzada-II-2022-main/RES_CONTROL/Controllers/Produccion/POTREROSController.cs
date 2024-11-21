using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using RES_CONTROL.Clases;
using RES_CONTROL.Models;

namespace RES_CONTROL.Controllers.Produccion
{
    public class POTREROSController : Controller
    {
        private GANADERAEntities db = new GANADERAEntities();
        private AyudantePotreros ayudante = new AyudantePotreros();

        [Authorize]
        // GET: POTREROS
        public ActionResult Index()
        {
            var pOTREROS = db.POTREROS.Include(p => p.ALIMENTACION).Include(p => p.FINCAS);
            return View(pOTREROS.ToList());
        }

        // GET: POTREROS/Details/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POTREROS pOTREROS = db.POTREROS.Find(id);
            if (pOTREROS == null)
            {
                return HttpNotFound();
            }
            return View(pOTREROS);
        }

        // GET: POTREROS/Create
        public ActionResult Crear()
        {
            ViewBag.ID_ALIMENTACION = new SelectList(db.ALIMENTACION, "ID_ALIMENTACION", "TIPO_ALIMENTACION");
            ViewBag.ID_FINCA = new SelectList(db.FINCAS, "ID_FINCA", "NOMBRE_FINCA");
            return View();
        }

        // POST: POTREROS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "ID_POTRERO,DESCRIPCION_POTRERO,ID_FINCA,ID_ALIMENTACION")] POTREROS pOTREROS)
        {
            if (ModelState.IsValid)
            {
                db.POTREROS.Add(pOTREROS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ALIMENTACION = new SelectList(db.ALIMENTACION, "ID_ALIMENTACION", "TIPO_ALIMENTACION", pOTREROS.ID_ALIMENTACION);
            ViewBag.ID_FINCA = new SelectList(db.FINCAS, "ID_FINCA", "NOMBRE_FINCA", pOTREROS.ID_FINCA);
            return View(pOTREROS);
        }

        // GET: POTREROS/Edit/5
        public ActionResult Modificar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POTREROS pOTREROS = db.POTREROS.Find(id);
            if (pOTREROS == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ALIMENTACION = new SelectList(db.ALIMENTACION, "ID_ALIMENTACION", "TIPO_ALIMENTACION", pOTREROS.ID_ALIMENTACION);
            ViewBag.ID_FINCA = new SelectList(db.FINCAS, "ID_FINCA", "NOMBRE_FINCA", pOTREROS.ID_FINCA);
            return View(pOTREROS);
        }

        // POST: POTREROS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modificar([Bind(Include = "ID_POTRERO,DESCRIPCION_POTRERO,ID_FINCA,ID_ALIMENTACION")] POTREROS pOTREROS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pOTREROS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ALIMENTACION = new SelectList(db.ALIMENTACION, "ID_ALIMENTACION", "TIPO_ALIMENTACION", pOTREROS.ID_ALIMENTACION);
            ViewBag.ID_FINCA = new SelectList(db.FINCAS, "ID_FINCA", "NOMBRE_FINCA", pOTREROS.ID_FINCA);
            return View(pOTREROS);
        }

        // GET: POTREROS/Delete/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POTREROS pOTREROS = db.POTREROS.Find(id);
            if (pOTREROS == null)
            {
                return HttpNotFound();
            }
            return View(pOTREROS);
        }

        // POST: POTREROS/Delete/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            POTREROS pOTREROS = db.POTREROS.Find(id);
            db.POTREROS.Remove(pOTREROS);
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



        public ActionResult ReportePorAlimentacion(string parte)
        {
            return View(ayudante.ReportePotreroPorAlimentacion(parte));
        }

        public ActionResult ReportePorFinca(string parte)
        {
            return View(ayudante.ReportePotrerosPorFinca(parte));
        }

    }
}

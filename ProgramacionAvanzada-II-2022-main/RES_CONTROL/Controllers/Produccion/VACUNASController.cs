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
    public class VACUNASController : Controller
    {
        private GANADERAEntities db = new GANADERAEntities();
        private AyudanteVacunas ayudante = new AyudanteVacunas();
        [Authorize]
        // GET: VACUNAS
        public ActionResult Index()
        {
            var vACUNAS = db.VACUNAS.Include(v => v.COLABORADORES).Include(v => v.RESES);
            return View(vACUNAS.ToList());
        }

        // GET: VACUNAS/Details/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VACUNAS vACUNAS = db.VACUNAS.Find(id);
            if (vACUNAS == null)
            {
                return HttpNotFound();
            }
            return View(vACUNAS);
        }

        // GET: VACUNAS/Create
        public ActionResult Crear()
        {
            ViewBag.ID_COLABORADOR = new SelectList(db.COLABORADORES, "ID_COLABORADOR", "IDENTIFICACION_LEGAL");
            ViewBag.ID_RES = new SelectList(db.RESES, "ID_RES", "RAZA");
            return View();
        }

        // POST: VACUNAS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "ID_VACUNA,NOMBRE_VACUNA,DESCRIPCION_VACUNA,FECHA,DOSIS,DOSIS_RECOMENDADA,ID_RES,ID_COLABORADOR")] VACUNAS vACUNAS)
        {
            if (ModelState.IsValid)
            {
                db.VACUNAS.Add(vACUNAS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_COLABORADOR = new SelectList(db.COLABORADORES, "ID_COLABORADOR", "IDENTIFICACION_LEGAL", vACUNAS.ID_COLABORADOR);
            ViewBag.ID_RES = new SelectList(db.RESES, "ID_RES", "RAZA", vACUNAS.ID_RES);
            return View(vACUNAS);
        }

        // GET: VACUNAS/Edit/5
        public ActionResult Modificar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VACUNAS vACUNAS = db.VACUNAS.Find(id);
            if (vACUNAS == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_COLABORADOR = new SelectList(db.COLABORADORES, "ID_COLABORADOR", "IDENTIFICACION_LEGAL", vACUNAS.ID_COLABORADOR);
            ViewBag.ID_RES = new SelectList(db.RESES, "ID_RES", "RAZA", vACUNAS.ID_RES);
            return View(vACUNAS);
        }

        // POST: VACUNAS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modificar([Bind(Include = "ID_VACUNA,NOMBRE_VACUNA,DESCRIPCION_VACUNA,FECHA,DOSIS,DOSIS_RECOMENDADA,ID_RES,ID_COLABORADOR")] VACUNAS vACUNAS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vACUNAS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_COLABORADOR = new SelectList(db.COLABORADORES, "ID_COLABORADOR", "IDENTIFICACION_LEGAL", vACUNAS.ID_COLABORADOR);
            ViewBag.ID_RES = new SelectList(db.RESES, "ID_RES", "RAZA", vACUNAS.ID_RES);
            return View(vACUNAS);
        }

        // GET: VACUNAS/Delete/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VACUNAS vACUNAS = db.VACUNAS.Find(id);
            if (vACUNAS == null)
            {
                return HttpNotFound();
            }
            return View(vACUNAS);
        }

        // POST: VACUNAS/Delete/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VACUNAS vACUNAS = db.VACUNAS.Find(id);
            db.VACUNAS.Remove(vACUNAS);
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



        public ActionResult ReportePorFecha(string parte)
        {
            return View(ayudante.ReporteVacunasPorFecha(parte));
        }

        public ActionResult ReportePorNombre(string parte)
        {
            return View(ayudante.ReporteVacunasPorNombre(parte));
        }


    }
}

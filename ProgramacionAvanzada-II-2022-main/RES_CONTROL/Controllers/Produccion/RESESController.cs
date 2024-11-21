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
    public class RESESController : Controller
    {
        private GANADERAEntities db = new GANADERAEntities();
        private AyudanteReses ayudante = new AyudanteReses();
        [Authorize]
        // GET: RESES
        public ActionResult Index()
        {
            var rESES = db.RESES.Include(r => r.POTREROS);
            return View(rESES.ToList());
        }

        // GET: RESES/Details/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESES rESES = db.RESES.Find(id);
            if (rESES == null)
            {
                return HttpNotFound();
            }
            return View(rESES);
        }

        // GET: RESES/Create
        public ActionResult Crear()
        {
            ViewBag.ID_POTRERO = new SelectList(db.POTREROS, "ID_POTRERO", "DESCRIPCION_POTRERO");
            return View();
        }

        // POST: RESES/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "ID_RES,RAZA,FIERRO,SEXO,FECHA_NACIMIENTO_APROX,ID_POTRERO")] RESES rESES)
        {
            if (ModelState.IsValid)
            {
                db.RESES.Add(rESES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_POTRERO = new SelectList(db.POTREROS, "ID_POTRERO", "DESCRIPCION_POTRERO", rESES.ID_POTRERO);
            return View(rESES);
        }

        // GET: RESES/Edit/5
        public ActionResult Modificar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESES rESES = db.RESES.Find(id);
            if (rESES == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_POTRERO = new SelectList(db.POTREROS, "ID_POTRERO", "DESCRIPCION_POTRERO", rESES.ID_POTRERO);
            return View(rESES);
        }

        // POST: RESES/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modificar([Bind(Include = "ID_RES,RAZA,FIERRO,SEXO,FECHA_NACIMIENTO_APROX,ID_POTRERO")] RESES rESES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rESES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_POTRERO = new SelectList(db.POTREROS, "ID_POTRERO", "DESCRIPCION_POTRERO", rESES.ID_POTRERO);
            return View(rESES);
        }

        // GET: RESES/Delete/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESES rESES = db.RESES.Find(id);
            if (rESES == null)
            {
                return HttpNotFound();
            }
            return View(rESES);
        }

        // POST: RESES/Delete/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RESES rESES = db.RESES.Find(id);
            db.RESES.Remove(rESES);
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



        public ActionResult ReportePorEdad(string parte)
        {
            return View(ayudante.ReporteResesPorEdad(parte));
        }

        public ActionResult ReportePorFierro(string parte)
        {
            return View(ayudante.ReporteResesPorFierro(parte));
        }

        public ActionResult ReportePorRaza(string parte)
        {
            return View(ayudante.ReporteResesPorRaza(parte));
        }

        public ActionResult ReportePorPotrero(string parte)
        {
            return View(ayudante.ReporteResesPorSennasPotrero(parte));
        }

        public ActionResult ReportePorSexo(string parte)
        {
            return View(ayudante.ReporteResesPorSexo(parte));
        }


    }
}

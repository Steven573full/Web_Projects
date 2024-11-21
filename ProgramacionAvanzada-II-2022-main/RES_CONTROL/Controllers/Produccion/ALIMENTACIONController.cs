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
    public class ALIMENTACIONController : Controller
    {
        private GANADERAEntities db = new GANADERAEntities();
        private AyudanteAlimentacion ayudante = new AyudanteAlimentacion();

        [Authorize]
        // GET: ALIMENTACION
        public ActionResult Index()
        {
            return View(db.ALIMENTACION.ToList());
        }

        // GET: ALIMENTACION/Details/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALIMENTACION aLIMENTACION = db.ALIMENTACION.Find(id);
            if (aLIMENTACION == null)
            {
                return HttpNotFound();
            }
            return View(aLIMENTACION);
        }

        // GET: ALIMENTACION/Create
        public ActionResult Crear()
        {
            return View();
        }

        // POST: ALIMENTACION/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "ID_ALIMENTACION,TIPO_ALIMENTACION,PROPOSITO")] ALIMENTACION aLIMENTACION)
        {
            if (ModelState.IsValid)
            {
                db.ALIMENTACION.Add(aLIMENTACION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aLIMENTACION);
        }

        // GET: ALIMENTACION/Edit/5
        public ActionResult Modificar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALIMENTACION aLIMENTACION = db.ALIMENTACION.Find(id);
            if (aLIMENTACION == null)
            {
                return HttpNotFound();
            }
            return View(aLIMENTACION);
        }

        // POST: ALIMENTACION/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modificar([Bind(Include = "ID_ALIMENTACION,TIPO_ALIMENTACION,PROPOSITO")] ALIMENTACION aLIMENTACION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aLIMENTACION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aLIMENTACION);
        }

        // GET: ALIMENTACION/Delete/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ALIMENTACION aLIMENTACION = db.ALIMENTACION.Find(id);
            if (aLIMENTACION == null)
            {
                return HttpNotFound();
            }
            return View(aLIMENTACION);
        }

        // POST: ALIMENTACION/Delete/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ALIMENTACION aLIMENTACION = db.ALIMENTACION.Find(id);
            db.ALIMENTACION.Remove(aLIMENTACION);
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



        /*Acciones perzonalizadas*/


        public ActionResult ReportePorTipo(string parte)
        {
            return View(ayudante.ReporteAlimentacionPorTipo(parte));
        }


        public ActionResult ReportePorProposito(string parte)
        {
            return View(ayudante.ReporteAlimentacionPorProposito(parte));
        }

    }
}

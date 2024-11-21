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
    public class COLABORADORESController : Controller
    {
        private GANADERAEntities db = new GANADERAEntities();
        private AyudanteColaboradores ayudante = new AyudanteColaboradores();

        [Authorize]
        // GET: COLABORADORES
        public ActionResult Index()
        {
            var cOLABORADORES = db.COLABORADORES.Include(c => c.USUARIOS);
            return View(cOLABORADORES.ToList());
        }

        // GET: COLABORADORES/Details/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COLABORADORES cOLABORADORES = db.COLABORADORES.Find(id);
            if (cOLABORADORES == null)
            {
                return HttpNotFound();
            }
            return View(cOLABORADORES);
        }

        // GET: COLABORADORES/Create
        public ActionResult Crear()
        {
            ViewBag.ID_USUARIO = new SelectList(db.USUARIOS, "ID_USUARIO", "EMAIL");
            return View();
        }

        // POST: COLABORADORES/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Crear([Bind(Include = "ID_COLABORADOR,IDENTIFICACION_LEGAL,NOMBRE,APELLIDOS,ROL,ID_USUARIO")] COLABORADORES cOLABORADORES)
        {
            if (ModelState.IsValid)
            {
                db.COLABORADORES.Add(cOLABORADORES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_USUARIO = new SelectList(db.USUARIOS, "ID_USUARIO", "EMAIL", cOLABORADORES.ID_USUARIO);
            return View(cOLABORADORES);
        }

        // GET: COLABORADORES/Edit/5
        public ActionResult Modificar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COLABORADORES cOLABORADORES = db.COLABORADORES.Find(id);
            if (cOLABORADORES == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_USUARIO = new SelectList(db.USUARIOS, "ID_USUARIO", "EMAIL", cOLABORADORES.ID_USUARIO);
            return View(cOLABORADORES);
        }

        // POST: COLABORADORES/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Modificar([Bind(Include = "ID_COLABORADOR,IDENTIFICACION_LEGAL,NOMBRE,APELLIDOS,ROL,ID_USUARIO")] COLABORADORES cOLABORADORES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOLABORADORES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_USUARIO = new SelectList(db.USUARIOS, "ID_USUARIO", "EMAIL", cOLABORADORES.ID_USUARIO);
            return View(cOLABORADORES);
        }

        // GET: COLABORADORES/Delete/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COLABORADORES cOLABORADORES = db.COLABORADORES.Find(id);
            if (cOLABORADORES == null)
            {
                return HttpNotFound();
            }
            return View(cOLABORADORES);
        }

        // POST: COLABORADORES/Delete/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            COLABORADORES cOLABORADORES = db.COLABORADORES.Find(id);
            db.COLABORADORES.Remove(cOLABORADORES);
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

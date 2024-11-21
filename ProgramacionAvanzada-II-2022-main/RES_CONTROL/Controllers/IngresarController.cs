using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Web.Security;
using RES_CONTROL.Models;
using RES_CONTROL.Clases;

namespace RES_CONTROL.Controllers
{
    public class IngresarController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario, string url)
        {
            if (IsValid(usuario))
            {
                FormsAuthentication.SetAuthCookie(usuario.EMAIL, false);
                if (usuario.ROL == "Administrativo")
                {
                    return RedirectToAction("IndexAdmin","home");
                }
                return RedirectToAction("Index", "Home");
            }
            TempData["Mensaje"] = "Credenciales incorrectas";
            return View(usuario);
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
            /*accion a mostrar, controlador donde se encuentra; en este caso despues de hacer el logoff*/
        }

        public bool IsValid(Usuario usuario)
        {
            return usuario.Autenticar();
        }
    }
}
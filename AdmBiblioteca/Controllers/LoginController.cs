using CapaNegocios.Acciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdmBiblioteca.Controllers
{
    public class LoginController : Controller
    {
        AccionesUsuario servicio = new AccionesUsuario();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IniciarSesion(FormCollection formCollection)
        {
            var tipoUsuario = formCollection.Get("tipoUsuario");
            if (tipoUsuario == "1")
            {
                var usuario = servicio.loginAdministrador(formCollection.Get("email"), formCollection.Get("password"));
                if (usuario == null)
                {
                    ModelState.AddModelError("email", "Email o contrasena no validos");
                    return View("Index");
                }
            }
            else
            {
                var estudiante = servicio.loginEstudiante(formCollection.Get("email"), formCollection.Get("password"));
                if (estudiante == null)
                {
                    ModelState.AddModelError("email", "Email o contrasena no validos");
                    return View("Index");
                }
            }

            return RedirectToAction("Index", "Libros");
        }
    }
}
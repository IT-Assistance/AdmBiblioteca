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
            Session["tipoUsuario"] = null;
            Session["nombre"] = null;
            Session["estudianteId"] = null;
            Session["idUsuario"] = null;
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
                }else
                {
                    Session["tipoUsuario"] = 1;
                    Session["nombre"] = usuario.Nombre;
                    Session["idUsuario"] = usuario.ID_Usuario;
                    return RedirectToAction("Index", "Libros");
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
                else
                {
                    Session["tipoUsuario"] = 2;
                    Session["nombre"] = estudiante.Nombre;
                    Session["estudianteId"] = estudiante.Matricula;
                    return RedirectToAction("Index", "Home");
                }
            }

        }
    }
}
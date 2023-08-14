using CapaModelo.Modelos;
using CapaNegocios.Acciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdmBiblioteca.Controllers
{
    public class ReservaLibroController : Controller
    {
        AccionesConsulta servicio = new AccionesConsulta();
        // GET: ReservaLibro
        public ActionResult Index()
        {
            var listaLibros = servicio.listLibros();
            var reservas = servicio.listResrvasLibros();
            var estudiantes = servicio.listEstudiantes();
            var model = new mReservaLibros()
            {
                Libros = listaLibros,
                ReservasLibros = reservas,
                Estudiantes = estudiantes
            };
            return View(model);
        }

        // GET: ReservaLibro/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReservaLibro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReservaLibro/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ReservaLibro/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReservaLibro/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ReservaLibro/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReservaLibro/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

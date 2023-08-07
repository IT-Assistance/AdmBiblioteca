using CapaDatos.Database;
using CapaNegocios.Acciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdmBiblioteca.Controllers
{
    public class LibrosController : Controller
    {

        AccionesConsulta servicio = new AccionesConsulta();
        // GET: Libros
        public ActionResult Index()
        {
            var list = servicio.listLibros();
            ViewBag.List = list;
            return View();
        }

        // GET: Libros/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Libros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Libros/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                TM_Libro libro = new TM_Libro()
                {
                    Nombre_Libro = collection.Get("nombre"),
                    Nombre_Autor = collection.Get("autor"),
                    Genero = collection.Get("genero"),
                    Numero_Paginas = int.Parse(collection.Get("paginas")),
                };

                var id = collection.Get("id");
                if (id != "")
                {
                    libro.ID_Libro = int.Parse(id);
                    servicio.actualizarLibro(libro);
                }
                else
                {
                    servicio.insertLibro(libro);

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Libros/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Libros/Edit/5
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

        // GET: Libros/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Libros/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                servicio.eliminarLibro(id);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }
    }
}

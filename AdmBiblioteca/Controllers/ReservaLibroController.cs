using CapaDatos.Database;
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
            var estudianteId = Session["estudianteId"]?.ToString();
            if(estudianteId != null)
            {
                reservas = reservas.Where(x => x.Matricula.ToString() == estudianteId).ToList();
            }
            var model = new mReservaLibros()
            {
                Libros = listaLibros,
                ReservasLibros = reservas,
                Estudiantes = estudiantes,
                EstudianteId = estudianteId
            };
            return View(model);
        }


        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                int matricula = collection.Get("estudianteId") != "" ? int.Parse(collection.Get("estudianteId")) : int.Parse(collection.Get("estudiante"));

                // TODO: Add insert logic here
                TD_Reserva_Libro item = new TD_Reserva_Libro()
                {
                    ID_Libro = int.Parse(collection.Get("libro")),
                    Matricula = matricula,
                    Inicio_Reserva = DateTime.Parse(collection.Get("fechaInicio")),
                    Final_Reserva = DateTime.Parse(collection.Get("fechaFin")),
                };

                var id = collection.Get("id");
                if (id != "")
                {
                    item.ID_Reserva_Libro = int.Parse(id);
                    servicio.actualizarReservaLibro(item);
                }
                else
                {
                    servicio.insertReservaLibro(item);

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                servicio.eliminarReservaLibro(id);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }


    }
}

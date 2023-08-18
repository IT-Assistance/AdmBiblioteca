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
    public class ReservaEspacioTrabajoController : Controller
    {
        AccionesConsulta servicio = new AccionesConsulta();
        // GET: ReservaEspacioTrabajo
        public ActionResult Index()
        {
            var espacios = servicio.listEspacioTrabajo();
            var reservas = servicio.listResrvasEspaciosTrabajo();
            var estudiantes = servicio.listEstudiantes();
            var estudianteId = Session["estudianteId"]?.ToString();
            if (estudianteId != null)
            {
                reservas = reservas.Where(x => x.Matricula.ToString() == estudianteId).ToList();
            }
            var model = new mReservaEspacioTrabajo()
            {
                EspaciosTrabajo = espacios,
                Reservas_Espacios = reservas,
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
                TD_Reserva_Espacio_Trabajo item = new TD_Reserva_Espacio_Trabajo()
                {
                    ID_Espacio = int.Parse(collection.Get("espacio")),
                    Matricula = matricula,
                    Inicio_Reserva = DateTime.Parse(collection.Get("fechaInicio")),
                    Final_Reserva = DateTime.Parse(collection.Get("fechaFin")),
                };

                var id = collection.Get("id");
                if (id != "")
                {
                    item.ID_Reserva_Espacio = int.Parse(id);
                    servicio.actualizarReservaEspacioTrabajo(item);
                }
                else
                {
                    servicio.insertReservaEspacioTrabajo(item);

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
                servicio.eliminarReservaEspacioTrabajo(id);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }
    }
}
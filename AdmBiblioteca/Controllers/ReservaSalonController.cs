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
    public class ReservaSalonController : Controller
    {
        // GET: ReservaSalon
        AccionesConsulta servicio = new AccionesConsulta();
        // GET: ReservaLibro
        public ActionResult Index()
        {
            var salones = servicio.listSalones();
            var reservas = servicio.listReservasSalon();
            var estudiantes = servicio.listEstudiantes();
            var estudianteId = Session["estudianteId"]?.ToString();
            if (estudianteId != null)
            {
                reservas = reservas.Where(x => x.Matricula.ToString() == estudianteId).ToList();
            }
            var model = new mReservaSalon()
            {
                Salones = salones,
                Reservas_Salones = reservas,
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
                // TODO: Add insert logic here
                TD_Reserva_salones_reunione item = new TD_Reserva_salones_reunione()
                {
                    ID_Salon = int.Parse(collection.Get("salon")),
                    Matricula = int.Parse(collection.Get("estudianteId")),
                    Inicio_Reserva = DateTime.Parse(collection.Get("fechaInicio")),
                    Final_Reserva = DateTime.Parse(collection.Get("fechaFin")),
                };

                var id = collection.Get("id");
                if (id != "")
                {
                    item.ID_Reserva_Salon = int.Parse(id);
                    servicio.actualizarReservaSalonReunion(item);
                }
                else
                {
                    servicio.insertReservaSalonReunion(item);

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
                servicio.eliminarReservaSalon(id);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }
    }
}
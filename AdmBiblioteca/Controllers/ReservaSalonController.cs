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
    }
}
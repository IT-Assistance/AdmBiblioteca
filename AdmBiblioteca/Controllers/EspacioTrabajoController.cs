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
    public class EspacioTrabajoController : Controller
    {
        AccionesConsulta servicio = new AccionesConsulta();
        // GET: EspacioTrabajo
        public ActionResult Index()
        {
            var espacios = servicio.listEspacioTrabajo();
            var model = new mEspacioTrabajo()
            {
                Espacio_Trabajos = espacios
            };
            return View(model);
        }


        // POST: SalonReuniones/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                TM_Espacio_Trabajo item = new TM_Espacio_Trabajo()
                {
                    Nombre_Espacio = collection.Get("nombre"),
                };

                var id = collection.Get("id");
                if (id != "")
                {
                    item.ID_Espacio = int.Parse(id);
                    servicio.actualizarEspacioTrabajo(item);
                }
                else
                {
                    servicio.insertEspacioTrabajo(item);

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: SalonReuniones/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                servicio.eliminarEspacioTrabajo(id);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }
    }
}
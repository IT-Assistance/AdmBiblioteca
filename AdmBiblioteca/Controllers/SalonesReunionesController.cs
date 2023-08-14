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
    public class SalonesReunionesController : Controller
    {
        AccionesConsulta servicio = new AccionesConsulta();
        // GET: SalonReuniones
        public ActionResult Index()
        {
            var list = servicio.listSalones();
            var modelo = new mSalonesReuniones()
            {
                Salones_Reuniones = list
            };
            return View(modelo);
        }

        // GET: SalonReuniones/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SalonReuniones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalonReuniones/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                TM_Salones_Reunione salon = new TM_Salones_Reunione()
                {
                    Nombre_Salon = collection.Get("nombre"),
                    Capacidad = int.Parse(collection.Get("capacidad")),
                };

                var id = collection.Get("id");
                if (id != "")
                {
                    salon.ID_Salon = int.Parse(id);
                    servicio.actualizarSalon(salon);
                }
                else
                {
                    servicio.inserSalon(salon);

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SalonReuniones/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SalonReuniones/Edit/5
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

        // GET: SalonReuniones/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SalonReuniones/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                servicio.eliminarSalon(id);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }
    }
}

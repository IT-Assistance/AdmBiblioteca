using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdmBiblioteca.Controllers
{
    public class SalonReunionesController : Controller
    {
        // GET: SalonReuniones
        public ActionResult Index()
        {
            return View();
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

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

using CapaDatos.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios.Acciones
{
    public class AccionesConsulta:AccionesBase
    {
        #region Listados
        public List<TM_Libro> listLibros()
        {
            return dbLibContext.TM_Libros.ToList();
        }

        public TM_Libro getLibro(int id)
        {
            return dbLibContext.TM_Libros.Where(i => i.ID_Libro == id).FirstOrDefault();
        }

        public TM_Salones_Reunione getSalon(int id)
        {
            return dbLibContext.TM_Salones_Reuniones.Where(i => i.ID_Salon == id).FirstOrDefault();
        }

        public List<TD_Reserva_Libro> listResrvasLibros()
        {
            return dbLibContext.TD_Reserva_Libros.ToList();
        }

        public List<TM_Estudiante> listEstudiantes()
        {
            return dbLibContext.TM_Estudiantes.ToList();
        }

        public List<TM_Salones_Reunione> listSalones()
        {
            return dbLibContext.TM_Salones_Reuniones.ToList();
        }

        public List<TM_Espacio_Trabajo> listEspacioTrabajo()
        {
            return dbLibContext.TM_Espacio_Trabajos.ToList();
        }

        #endregion


        public void insertLibro(TM_Libro libro)
        {
            libro.FlagActivo = true;
            dbLibContext.TM_Libros.InsertOnSubmit(libro);
            dbLibContext.SubmitChanges();
        }

        public void actualizarLibro(TM_Libro libro)
        {
            var item = getLibro(libro.ID_Libro);
            item.Nombre_Autor = libro.Nombre_Autor;
            item.Nombre_Libro = libro.Nombre_Libro;
            item.Numero_Paginas = libro.Numero_Paginas;
            item.Genero = libro.Genero;

            dbLibContext.SubmitChanges();
        }

        public void inserSalon(TM_Salones_Reunione salon)
        {
            salon.FlagActivo = true;
            dbLibContext.TM_Salones_Reuniones.InsertOnSubmit(salon);
            dbLibContext.SubmitChanges();
        }

        public void actualizarSalon(TM_Salones_Reunione salon)
        {
            var item = getSalon(salon.ID_Salon);
            item.Nombre_Salon = salon.Nombre_Salon;
            item.Capacidad = salon.Capacidad;

            dbLibContext.SubmitChanges();
        }

        public void eliminarSalon(int id)
        {
            var item = getSalon(id);
            item.FlagActivo = false;
            dbLibContext.SubmitChanges();
        }

        public void eliminarLibro(int id)
        {
            var item = getLibro(id);
            item.FlagActivo = false;
            dbLibContext.SubmitChanges();
        }
    }
}

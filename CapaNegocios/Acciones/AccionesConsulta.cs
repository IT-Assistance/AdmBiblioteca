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
            item.FlagActivo = !item.FlagActivo;
            dbLibContext.SubmitChanges();
        }

        public void eliminarLibro(int id)
        {
            var item = getLibro(id);
            item.FlagActivo = !item.FlagActivo;
            dbLibContext.SubmitChanges();
        }

      
        public TM_Espacio_Trabajo getEspacioTrabajo(int id)
        {
            return dbLibContext.TM_Espacio_Trabajos.Where(i => i.ID_Espacio == id).FirstOrDefault();
        }

        public void eliminarEspacioTrabajo(int id)
        {
            var item = getEspacioTrabajo(id);
            item.FlagActivo = !item.FlagActivo;
            dbLibContext.SubmitChanges();
        }

        public void actualizarEspacioTrabajo(TM_Espacio_Trabajo espacio)
        {
            var item = getEspacioTrabajo(espacio.ID_Espacio);
            item.Nombre_Espacio = espacio.Nombre_Espacio;

            dbLibContext.SubmitChanges();
        }

        public void insertEspacioTrabajo(TM_Espacio_Trabajo item)
        {
            item.FlagActivo = true;
            dbLibContext.TM_Espacio_Trabajos.InsertOnSubmit(item);
            dbLibContext.SubmitChanges();
        }



        public List<TD_Reserva_Espacio_Trabajo> listResrvasEspaciosTrabajo()
        {
            return dbLibContext.TD_Reserva_Espacio_Trabajos.ToList();
        }
        public TD_Reserva_Espacio_Trabajo getReservaEspacioTrabajo(int id)
        {
            return dbLibContext.TD_Reserva_Espacio_Trabajos.Where(i => i.ID_Reserva_Espacio == id).FirstOrDefault();
        }

        public void eliminarReservaEspacioTrabajo(int id)
        {
            var item = getReservaEspacioTrabajo(id);
            item.FlagActivo = !item.FlagActivo;
            dbLibContext.SubmitChanges();
        }

        public void actualizarReservaEspacioTrabajo(TD_Reserva_Espacio_Trabajo espacio)
        {
            var item = getReservaEspacioTrabajo(espacio.ID_Reserva_Espacio);
            item.ID_Espacio = espacio.ID_Espacio;
            item.Inicio_Reserva = espacio.Inicio_Reserva;
            item.Final_Reserva = espacio.Final_Reserva;
            item.Matricula = espacio.Matricula;

            dbLibContext.SubmitChanges();
        }

        public void insertReservaEspacioTrabajo(TD_Reserva_Espacio_Trabajo item)
        {
            item.FlagActivo = true;
            dbLibContext.TD_Reserva_Espacio_Trabajos.InsertOnSubmit(item);
            dbLibContext.SubmitChanges();
        }



        public List<TD_Reserva_salones_reunione> listReservasSalon()
        {
            return dbLibContext.TD_Reserva_salones_reuniones.ToList();
        }
        public TD_Reserva_salones_reunione getReservaSalon(int id)
        {
            return dbLibContext.TD_Reserva_salones_reuniones.Where(i => i.ID_Reserva_Salon == id).FirstOrDefault();
        }

        public void eliminarReservaSalon(int id)
        {
            var item = getReservaSalon(id);
            item.FlagActivo = !item.FlagActivo;
            dbLibContext.SubmitChanges();
        }

        public void actualizarReservaSalonReunion(TD_Reserva_salones_reunione espacio)
        {
            var item = getReservaSalon(espacio.ID_Reserva_Salon);
            item.ID_Salon = espacio.ID_Salon;
            item.Inicio_Reserva = espacio.Inicio_Reserva;
            item.Final_Reserva = espacio.Final_Reserva;
            item.Matricula = espacio.Matricula;

            dbLibContext.SubmitChanges();
        }

        public void insertReservaSalonReunion(TD_Reserva_salones_reunione item)
        {
            item.FlagActivo = true;
            dbLibContext.TD_Reserva_salones_reuniones.InsertOnSubmit(item);
            dbLibContext.SubmitChanges();
        }




        public TD_Reserva_Libro getReservaLibro(int id)
        {
            return dbLibContext.TD_Reserva_Libros.Where(i => i.ID_Reserva_Libro == id).FirstOrDefault();
        }

        public void eliminarReservaLibro(int id)
        {
            var item = getReservaLibro(id);
            item.FlagActivo = !item.FlagActivo;
            dbLibContext.SubmitChanges();
        }

        public void actualizarReservaLibro(TD_Reserva_Libro espacio)
        {
            var item = getReservaLibro(espacio.ID_Reserva_Libro);
            item.ID_Libro = espacio.ID_Libro;
            item.Inicio_Reserva = espacio.Inicio_Reserva;
            item.Final_Reserva = espacio.Final_Reserva;
            item.Matricula = espacio.Matricula;

            dbLibContext.SubmitChanges();
        }

        public void insertReservaLibro(TD_Reserva_Libro item)
        {
            item.FlagActivo = true;
            dbLibContext.TD_Reserva_Libros.InsertOnSubmit(item);
            dbLibContext.SubmitChanges();
        }
    }
}

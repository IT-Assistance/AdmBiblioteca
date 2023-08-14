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

        public void eliminarLibro(int id)
        {
            var item = getLibro(id);
            item.FlagActivo = false;
            dbLibContext.SubmitChanges();
        }
    }
}

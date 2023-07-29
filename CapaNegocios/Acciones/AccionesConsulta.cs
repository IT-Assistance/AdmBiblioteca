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

        public List<TM_Salones_Reunione> listSalones()
        {
            return dbLibContext.TM_Salones_Reuniones.ToList();
        }

        public List<TM_Espacio_Trabajo> listEspacioTrabajo()
        {
            return dbLibContext.TM_Espacio_Trabajos.ToList();
        }

        #endregion
    }
}

using CapaDatos.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo.Modelos
{
    public class mReservaLibros
    {
        public List<TM_Libro> Libros { get; set; }
        public List<TM_Estudiante> Estudiantes { get; set; }
        public List<TD_Reserva_Libro> ReservasLibros { get; set; }
        public string EstudianteId { get; set; }
    }
}

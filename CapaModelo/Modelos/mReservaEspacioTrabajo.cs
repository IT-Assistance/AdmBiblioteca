using CapaDatos.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo.Modelos
{
    public class mReservaEspacioTrabajo
    {
        public List<TD_Reserva_Espacio_Trabajo> Reservas_Espacios { get; set; }
        public List<TM_Estudiante> Estudiantes { get; set; }
        public string EstudianteId { get; set; }
        public List<TM_Espacio_Trabajo> EspaciosTrabajo { get; set; }
    }
}

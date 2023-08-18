using CapaDatos.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo.Modelos
{
    public class mReservaSalon
    {
        public List<TD_Reserva_salones_reunione> Reservas_Salones { get; set; }
        public List<TM_Estudiante> Estudiantes { get; set; }
        public string EstudianteId { get; set; }
        public List<TM_Salones_Reunione> Salones { get; set; }
    }
}

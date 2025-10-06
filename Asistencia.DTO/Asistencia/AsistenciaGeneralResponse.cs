using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.DTO.Asistencia
{
    public class AsistenciaGeneralResponse
    {
        public string CodigoMarcador { get; set; }
        public string  NombreMarcador { get; set; }

        //public DateTime FechaHoraMarcacion { get; set; }
        public string CodigoEmpleado { get; set; }
        public string NombreEmpleado { get;set; }
        public string FechaFormateada { get; set; }
        public string TiempoFormateado { get; set; }

        public string TiempoFormateadoSicape { get; set; }

        public string horaingreso1 { get; set; }
        public string horasalida1 { get; set; }
        public string horaingreso2 { get; set; }
        public string horasalida2 { get; set; }
        public string hoingreso3 { get; set; }
        public string horasalida3 { get; set; }
        public string horaingreso4 { get; set; }
        public string horasalida4 { get; set; }
        public string horafinal { get; set; }
        public string observatipo { get; set; }
            public string dia { get; set; }
        public string obsfinal { get; set; }
        public string descuento { get; set; }
        public string total { get; set; }
        public string unidadDepartamento { get; set; }
        public string hrfalta { get; set; }
        public string cpumarcador { get; set; }
        public int departamentoid { get; set; }


    }
}

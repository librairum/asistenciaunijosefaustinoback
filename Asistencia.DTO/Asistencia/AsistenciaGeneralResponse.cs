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

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.DTO.Horario
{
    public class HorarioGeneralResponse
    {

        public int IdEmpleado { get; set; }
        public string nroDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public string NombreDept { get; set; }
        public string NombreCargo { get; set; } 
        public string lunes { get; set; }
        public string martes { get; set; }
        public string miercoles { get; set; }
        public string jueves { get; set; }
        public string viernes { get; set; }
        public string sabado { get; set; }
        public string domingo { get; set; }

    }
}

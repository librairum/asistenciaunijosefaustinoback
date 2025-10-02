using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.DTO.Horario
{
    public class HorarioPersonalRequest
    {
        public string EmpresaCod { get; set; }
        public int IdEmpleado { get; set; }
        
        public string dia { get; set; }
        public string IdMotivo { get; set; }
        public string horaingreso { get; set; }
        public string horasalida { get; set; }

    }
}

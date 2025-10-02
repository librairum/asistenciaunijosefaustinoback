using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.DTO.MotivoHorario
{
    public class MotivoHorarioResponse
    {
        public string EmpresaCod { get; set; }
        public string IdMotivo { get; set; }
        public string   Descripcion { get; set; }

        public string flagCalculaTiempo { get; set; }
    }
}

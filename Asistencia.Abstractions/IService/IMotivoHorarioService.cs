using Asistencia.DTO.Common;
using Asistencia.DTO.Horario;
using Asistencia.DTO.MotivoHorario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.Abstractions.IService
{
    public interface IMotivoHorarioService
    {

        public Task<ResultDTO<MotivoHorarioResponse>> SpTraeHorarios(string EmpresaCod);
        public Task<ResultDTO<string>> SpInserta(MotivoHorarioRequest entidad);
        public Task<ResultDTO<string>> SpActualiza(MotivoHorarioRequest entidad);
        public Task<ResultDTO<string>> SpEliminar(string codigoEmpresa, string codigoMotivo);
    }
}

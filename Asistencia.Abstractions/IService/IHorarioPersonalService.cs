using Asistencia.DTO.Common;
using Asistencia.DTO.Horario;
using Asistencia.DTO.HorarioPersonal;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.Abstractions.IService
{
    public interface IHorarioPersonalService
    {
        public Task<ResultDTO<HorarioGeneralResponse>> SpTraeHorarios(string EmpresaCod);
        public Task<ResultDTO<HorarioPersonalResponse>> SpTraeHorarioDet(string EmpresaCod, string idpersonal, string dia);
        public Task<ResultDTO<string>> SpInserta(HorarioPersonalRequest entidad);
        public Task<ResultDTO<string>> SpActualiza(HorarioPersonalRequest entidad);
        public Task<ResultDTO<string>> SpActualizaHorariosMasivo(HorarioMasivoRequest entidad);
        public Task<ResultDTO<string>> SpActualizaHorarioDinamico(HorarioPersonalRequest entidad);

    }
}

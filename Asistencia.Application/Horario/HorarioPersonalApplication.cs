using Asistencia.Abstractions.IApplication;
using Asistencia.Abstractions.IService;
using Asistencia.DTO.Common;
using Asistencia.DTO.Horario;
using Asistencia.DTO.HorarioPersonal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.Application.Horario
{
    public class HorarioPersonalApplication : IHorarioPersonalApplication
    {
        private IHorarioPersonalService _service;

        public HorarioPersonalApplication(IHorarioPersonalService service)
        {
            _service = service;
        }

        public async Task<ResultDTO<string>> SpActualiza(HorarioPersonalRequest entidad)
        {
            return await this._service.SpActualiza(entidad);
        }

        public async Task<ResultDTO<string>> SpInserta(HorarioPersonalRequest entidad)
        {
            return await this._service.SpInserta(entidad);
        }

        public async Task<ResultDTO<HorarioGeneralResponse>> SpTraeHorarios(string EmpresaCod)
        {
            return await this._service.SpTraeHorarios(EmpresaCod);
        }

        public async Task<ResultDTO<HorarioPersonalResponse>> SpTraeHorarioDet(string EmpresaCod, string idpersonal, string dia)
        {
            return await this._service.SpTraeHorarioDet(EmpresaCod, idpersonal, dia);
        }

        public async Task<ResultDTO<string>> SpActualizaHorariosMasivo(HorarioMasivoRequest entidad)
        {
            return await this._service.SpActualizaHorariosMasivo(entidad);
        }

        public async Task<ResultDTO<string>> SpActualizaHorarioDinamico(HorarioPersonalRequest entidad)
        {
            return await this._service.SpActualizaHorarioDinamico(entidad);
        }
    }
}

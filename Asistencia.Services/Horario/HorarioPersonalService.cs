using Asistencia.Abstractions.IRepository;
using Asistencia.Abstractions.IService;
using Asistencia.DTO.Common;
using Asistencia.DTO.Horario;
using Asistencia.DTO.HorarioPersonal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.Services.Horario
{
    public class HorarioPersonalService : IHorarioPersonalService
    {

        private IHorarioPersonalRepository _repositorio; 
        public HorarioPersonalService(IHorarioPersonalRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<ResultDTO<string>> SpActualiza(HorarioPersonalRequest entidad)
        {
            return await this._repositorio.SpActualiza(entidad);
        }

        public async Task<ResultDTO<string>> SpInserta(HorarioPersonalRequest entidad)
        {
            return await this._repositorio.SpInserta(entidad);
        }

        public async Task<ResultDTO<HorarioGeneralResponse>> SpTraeHorarios(string EmpresaCod)
        {
            return await this._repositorio.SpTraeHorarios(EmpresaCod);
        }

        public async Task<ResultDTO<HorarioPersonalResponse>> SpTraeHorarioDet(string EmpresaCod, string idpersonal, string dia)
        {
            return await this._repositorio.SpTraeHorarioDet(EmpresaCod, idpersonal, dia);
        }

        public async Task<ResultDTO<string>> SpActualizaHorariosMasivo(HorarioMasivoRequest entidad)
        {
            return await this._repositorio.SpActualizaHorariosMasivo(entidad);
        }

        public async Task<ResultDTO<string>> SpActualizaHorarioDinamico(HorarioPersonalRequest entidad)
        {
            return await this._repositorio.SpActualizaHorarioDinamico(entidad);
        }
    }
}

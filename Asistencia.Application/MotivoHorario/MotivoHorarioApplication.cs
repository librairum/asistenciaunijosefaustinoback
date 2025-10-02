using Asistencia.Abstractions.IApplication;
using Asistencia.Abstractions.IRepository;
using Asistencia.Abstractions.IService;
using Asistencia.DTO.Common;
using Asistencia.DTO.MotivoHorario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.Application.MotivoHorario
{
    
    
    public class MotivoHorarioApplication : IMotivoHorarioApplication
    {
        private IMotivoHorarioService _service;    
        public MotivoHorarioApplication(IMotivoHorarioService service)
        {
            _service = service;
        }

        public async Task<ResultDTO<string>> SpActualiza(MotivoHorarioRequest entidad)
        {
            return await this._service.SpActualiza(entidad);
        }

        public async Task<ResultDTO<string>> SpEliminar(string codigoEmpresa, string codigoMotivo)
        {
            return await this._service.SpEliminar(codigoEmpresa, codigoMotivo);
        }

        public async Task<ResultDTO<string>> SpInserta(MotivoHorarioRequest entidad)
        {
            return await this._service.SpInserta(entidad);
        }

        public async Task<ResultDTO<MotivoHorarioResponse>> SpTraeHorarios(string EmpresaCod)
        {
            return await this._service.SpTraeHorarios(EmpresaCod);
        }
    }
}

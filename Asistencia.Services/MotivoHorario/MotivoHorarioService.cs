using Asistencia.Abstractions.IRepository;
using Asistencia.Abstractions.IService;
using Asistencia.DTO.Common;
using Asistencia.DTO.MotivoHorario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.Services.MotivoHorario
{
    public class MotivoHorarioService : IMotivoHorarioService
    {
        private IMotivoHorarioRepository _repository;
        public MotivoHorarioService(IMotivoHorarioRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResultDTO<string>> SpActualiza(MotivoHorarioRequest entidad)
        {
            return await this._repository.SpActualiza(entidad);
        }

        public async Task<ResultDTO<string>> SpEliminar(string empresaCod, 
            string IdMotivo)
        {
            return await this._repository.SpEliminar(empresaCod, IdMotivo);

        }


        public async  Task<ResultDTO<string>> SpInserta(MotivoHorarioRequest entidad)
        {
            return await this._repository.SpInserta(entidad);
        }


        public async Task<ResultDTO<MotivoHorarioResponse>> SpTraeHorarios(string EmpresaCod)
        {
            return await this._repository.SpTraeHorarios(EmpresaCod);
        }

   
    }
}

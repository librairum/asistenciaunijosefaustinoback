using Asistencia.Abstractions.IRepository;
using Asistencia.Abstractions.IService;
using Asistencia.DTO.Common;
using Asistencia.DTO.Permisos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.Services.Permisos
{
    internal class PermisosService : IPermisosService
    {
        private IPermisosRepository _permisosRepository;
        public PermisosService(IPermisosRepository permisosRepository)
        {
            _permisosRepository = permisosRepository;
        }

        public async Task<ResultDTO<string>> SpInsertaMenuxPerfil(PermisosRequest request)
        {
            return await this._permisosRepository.SpInsertaMenuxPerfil(request);
        }

        public async Task<ResultDTO<TodoPermisosResponse>> SpTodoMenuxPerfil(string codigoperfil, string codmodulo)
        {
            return await this._permisosRepository.SpTodoMenuxPerfil(codigoperfil, codmodulo);
        }

        public async Task<ResultDTO<PermisosxPerfilResponse>> SpTraeMenuxPerfil(string codigoPerfil, string codmodulo)
        {
            return await this._permisosRepository.SpTraeMenuxPerfil(codigoPerfil, codmodulo);
        }
    }
}

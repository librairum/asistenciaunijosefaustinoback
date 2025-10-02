using Asistencia.Abstractions.IApplication;
using Asistencia.Abstractions.IService;
using Asistencia.DTO.Common;
using Asistencia.DTO.Permisos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.Application.Permisos
{
    public class PermisosApplication: IPermisosApplication
    {
        private IPermisosService _permisosService;
        public PermisosApplication(IPermisosService permisosService)
        {
            _permisosService = permisosService;
        }

        public async Task<ResultDTO<string>> SpInsertaMenuxPerfil(PermisosRequest request)
        {
            return await this._permisosService.SpInsertaMenuxPerfil(request);
        }

        public async Task<ResultDTO<TodoPermisosResponse>> SpTodoMenuxPerfil(string codigoperfil, string codmodulo)
        {
            return await this._permisosService.SpTodoMenuxPerfil(codigoperfil, codmodulo);
        }

        public async Task<ResultDTO<PermisosxPerfilResponse>> SpTraeMenuxPerfil(string codigoPerfil, string codmodulo)
        {
            return await this._permisosService.SpTraeMenuxPerfil(codigoPerfil, codmodulo);
        }
    }
}

using Asistencia.Abstractions.IApplication;
using Asistencia.Abstractions.IService;
using Asistencia.DTO.Common;
using Asistencia.DTO.Perfil;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.Application.Perfil
{
    public class PerfilApplication:IPerfilApplication
    {

        private IPerfilService _perfilService;

        public PerfilApplication(IPerfilService perfilService)
        {
            _perfilService = perfilService;
        }

        public async Task<ResultDTO<string>> SpActualiza(PerfilRequest request)
        {
          
           
            return await this._perfilService.SpActualiza(request);
        }

        public async  Task<ResultDTO<string>> SpElimina(string codigo)
        {
            return await this._perfilService.SpElimina(codigo);
        }

        public async  Task<ResultDTO<string>> SpInserta(PerfilRequest request)
        {
            return await this._perfilService.SpInserta(request);
        }

        public async  Task<ResultDTO<PerfilResponse>> SpTraePerfil()
        {
            return await this._perfilService.SpTraePerfil();
        }
    }
}

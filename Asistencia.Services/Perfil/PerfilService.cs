using Asistencia.Abstractions.IRepository;
using Asistencia.Abstractions.IService;
using Asistencia.DTO.Common;
using Asistencia.DTO.Perfil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.Services.Perfil
{
    public class PerfilService : IPerfilService
    {
        private IPerfilRepository _perfilRepositorio;
        public PerfilService(IPerfilRepository perfilRepositorio)
        {
            _perfilRepositorio = perfilRepositorio;
        }
    
        public async Task<ResultDTO<string>> SpActualiza(PerfilRequest request)
        {
            return await this._perfilRepositorio.SpActualiza(request);
        }

        public async  Task<ResultDTO<string>> SpElimina(string codigo)
        {
            return await this._perfilRepositorio.SpElimina(codigo);
        }

        public async  Task<ResultDTO<string>> SpInserta(PerfilRequest request)
        {
            return await this._perfilRepositorio.SpInserta(request);
        }

        public async Task<ResultDTO<PerfilResponse>> SpTraePerfil()
        {
            return await this._perfilRepositorio.SpTraePerfil();
        }
    }
}

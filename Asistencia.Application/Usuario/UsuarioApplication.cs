using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asistencia.Abstractions.IApplication;
using Asistencia.Abstractions.IService;

using Asistencia.DTO.Common;
using Asistencia.DTO.Usuario;
namespace Asistencia.Application.Usuario
{
    public class UsuarioApplication:IUsuarioApplication
    {
        private IUsuarioService _usuarioService;

        public UsuarioApplication(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task<ResultDTO<string>> SpActualizarUsuario(UsuarioCreateRequest request)
        {
            return await this._usuarioService.SpActualizarUsuario(request);
        }

        public async Task<ResultDTO<string>> SpEliminaUsuario(string codigo, string cuentacod, string empresacod)
        {
            return await this._usuarioService.SpEliminaUsuario(codigo, cuentacod, empresacod);
        }

        public async Task<ResultDTO<string>> SpInsertaUsuario(UsuarioCreateRequest request)
        {
            return await this._usuarioService.SpInsertaUsuario(request);
        }

        public async Task<ResultDTO<UsuarioListResponse>> SpListaUsuaurio()
        {
            return await this._usuarioService.SpListaUsuaurio();
        }
    }
}

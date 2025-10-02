using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asistencia.DTO.Common;
using Asistencia.DTO.Usuario;

using Asistencia.Abstractions.IRepository;
using Asistencia.Abstractions.IService;

namespace Asistencia.Services.Usuario
{
    public class UsuarioService : IUsuarioService
    {

        private IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            this._usuarioRepository = usuarioRepository;
        }
        public async Task<ResultDTO<string>> SpActualizarUsuario(UsuarioCreateRequest request)
        {
            return await _usuarioRepository.SpActualizarUsuario(request);
        }

        public async Task<ResultDTO<string>> SpEliminaUsuario(string codigo, string cuentacod, string empresacod)
        {
            return await _usuarioRepository.SpEliminaUsuario(codigo, cuentacod, empresacod);
        }

        public async Task<ResultDTO<string>> SpInsertaUsuario(UsuarioCreateRequest request)
        {
            return await _usuarioRepository.SpInsertaUsuario(request);
        }

        public async Task<ResultDTO<UsuarioListResponse>> SpListaUsuaurio()
        {
            return await _usuarioRepository.SpListaUsuaurio();
        }
    }
}

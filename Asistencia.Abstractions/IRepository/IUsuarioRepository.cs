using Asistencia.DTO.Common;
using Asistencia.DTO.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.Abstractions.IRepository
{
    public interface IUsuarioRepository
    {
        public Task<ResultDTO<string>> SpInsertaUsuario(UsuarioCreateRequest request);

        public Task<ResultDTO<string>> SpActualizarUsuario(UsuarioCreateRequest request);
        public Task<ResultDTO<string>> SpEliminaUsuario(string codigo, string cuentacod, string empresacod);
        public Task<ResultDTO<UsuarioListResponse>> SpListaUsuaurio();

    }
}

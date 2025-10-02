using Asistencia.DTO.Common;
using Asistencia.DTO.Permisos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.Abstractions.IRepository
{
    public interface IPermisosRepository
    {
        public Task<ResultDTO<string>> SpInsertaMenuxPerfil(PermisosRequest request);
        public Task<ResultDTO<PermisosxPerfilResponse>> SpTraeMenuxPerfil(string codigoPerfil,
         string codModulo);
        public Task<ResultDTO<TodoPermisosResponse>> SpTodoMenuxPerfil(string codigoperfil, string codmodulo);
    }
}

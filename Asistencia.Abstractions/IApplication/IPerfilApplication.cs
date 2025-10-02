using Asistencia.DTO.Common;
using Asistencia.DTO.Perfil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.Abstractions.IApplication
{
    public interface IPerfilApplication
    {
        public Task<ResultDTO<string>> SpInserta(PerfilRequest request);

        public Task<ResultDTO<string>> SpActualiza(PerfilRequest request);
        public Task<ResultDTO<string>> SpElimina(string codigo);
        public Task<ResultDTO<PerfilResponse>> SpTraePerfil();

    }
}

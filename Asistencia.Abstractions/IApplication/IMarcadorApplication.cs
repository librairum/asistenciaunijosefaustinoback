using Asistencia.DTO.Common;
using Asistencia.DTO.Marcador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.Abstractions.IApplication
{
    public interface IMarcadorApplication
    {
        public Task<ResultDTO<string>> SpInserta(MarcadorRequest request);
        //public Task<ResultDTO<string>> SpActualiza(MarcadorRequest request);
        public Task<ResultDTO<string>> SpElimina(string codigoMarcadorCliente, string codigoMarcadorProveedor);
        public Task<ResultDTO<MarcadorResponse>> SpTrae();
    }
}

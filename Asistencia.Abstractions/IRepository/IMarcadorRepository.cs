using Asistencia.DTO.Common;
using Asistencia.DTO.Marcador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.Abstractions.IRepository
{
    public interface IMarcadorRepository
    {
        public Task<ResultDTO<string>> SpInserta(MarcadorRequest request);
        //public Task<ResultDTO<string>> SpActualiza(MarcadorRequest request);
        public Task<ResultDTO<string>> SpElimina(string codigoMarcadorCliente, string  codigoMarcadorProveedor);
        public Task<ResultDTO<MarcadorResponse>> SpTrae();

        /*
        @MarcadorCorpacCod  varchar(20),            
@MarcadorSupremaCod nvarchar(255),          
        */
    }
}

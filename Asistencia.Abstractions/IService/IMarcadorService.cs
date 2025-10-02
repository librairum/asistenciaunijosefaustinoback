using Asistencia.DTO.Common;
using Asistencia.DTO.Marcador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.Abstractions.IService
{
    public interface IMarcadorService
    {
        /*
         Spu_Int_Ins_Marcadores
Spu_Int_Trae_Marcadores
Spu_Int_Del_Marcadores
         */
        public Task<ResultDTO<string>> SpInserta(MarcadorRequest request);
        //public Task<ResultDTO<string>> SpActualiza(MarcadorRequest request);
        public Task<ResultDTO<string>> SpElimina(string codigoMarcadorCliente, string codigoMarcadorProveedor);
        public Task<ResultDTO<MarcadorResponse>> SpTrae();



    }
}

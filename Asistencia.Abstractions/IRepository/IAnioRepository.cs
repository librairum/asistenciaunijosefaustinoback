using Asistencia.DTO.Anio;
using Asistencia.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.Abstractions.IRepository
{
    public interface IAnioRepository
    {
        public Task<ResultDTO<string>> SpInsertaAnio(AnioRequest request);
        public Task<ResultDTO<string>> SpActualizaAnio(AnioRequest request);
        public Task<ResultDTO<string>> SpEliminaAnio(string codigo);
        public Task<ResultDTO<AnioResponse>> SpTraeAnio();

        //trae los meses
        public Task<ResultDTO<MesResponse>> SpTraeMeses();

    }
}

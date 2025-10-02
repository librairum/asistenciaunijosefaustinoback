using Asistencia.Abstractions.IApplication;
using Asistencia.Abstractions.IService;
using Asistencia.DTO.Anio;
using Asistencia.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.Application.Anio
{
    public class AnioApplication : IAnioApplication
    {

        private IAnioService _anioservice;
        public AnioApplication(IAnioService anioservice)
        {
            _anioservice = anioservice;
        }

        public async Task<ResultDTO<string>> SpActualizaAnio(AnioRequest request)
        {
            return await this._anioservice.SpActualizaAnio(request);
        }

        public async  Task<ResultDTO<string>> SpEliminaAnio(string codigo)
        {
            return await this._anioservice.SpEliminaAnio(codigo);
        }

        public async Task<ResultDTO<string>> SpInsertaAnio(AnioRequest request)
        {
            return await this._anioservice.SpInsertaAnio(request);
        }

        public async Task<ResultDTO<AnioResponse>> SpTraeAnio()
        {
            return await this._anioservice.SpTraeAnio();
        }

        public async Task<ResultDTO<MesResponse>> SpTraeMeses()
        {
            return await this._anioservice.SpTraeMeses();
        }
    }
}

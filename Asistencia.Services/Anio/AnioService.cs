using Asistencia.Abstractions.IRepository;
using Asistencia.Abstractions.IService;
using Asistencia.DTO.Anio;
using Asistencia.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.Services.Anio
{
    public class AnioService : IAnioService
    {

        private IAnioRepository _aniorepositorio;
        public AnioService(IAnioRepository anioRepositorio)
        {
            this._aniorepositorio = anioRepositorio;
        }
        public async Task<ResultDTO<string>> SpActualizaAnio(AnioRequest request)
        {
            return await  this._aniorepositorio.SpActualizaAnio(request);
        }

        public async  Task<ResultDTO<string>> SpEliminaAnio(string codigo)
        {
            return await this._aniorepositorio.SpEliminaAnio(codigo);
        }

        public async Task<ResultDTO<string>> SpInsertaAnio(AnioRequest request)
        {
            return await this._aniorepositorio.SpInsertaAnio(request);
        }

        public async Task<ResultDTO<AnioResponse>> SpTraeAnio()
        {
            return await this._aniorepositorio.SpTraeAnio();
        }

        public async Task<ResultDTO<MesResponse>> SpTraeMeses()
        {
            return await this._aniorepositorio.SpTraeMeses();
        }
    }
}

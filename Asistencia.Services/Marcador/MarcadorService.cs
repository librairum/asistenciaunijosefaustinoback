using Asistencia.Abstractions.IRepository;
using Asistencia.Abstractions.IService;
using Asistencia.DTO.Common;
using Asistencia.DTO.Marcador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.Services.Marcador
{
    public class MarcadorService : IMarcadorService
    {

        private IMarcadorRepository _marcadorRepositorio;
        public MarcadorService(IMarcadorRepository marcadorRepositorio)
        {
            _marcadorRepositorio = marcadorRepositorio;
        }

        public async Task<ResultDTO<string>> SpElimina(string codigoMarcadorCliente, string codigoMarcadorProveedor)
        {
            return await this._marcadorRepositorio.SpElimina(codigoMarcadorCliente, codigoMarcadorProveedor);
        }

        public async  Task<ResultDTO<string>> SpInserta(MarcadorRequest request)
        {
            return await this._marcadorRepositorio.SpInserta(request);
        }

        public async Task<ResultDTO<MarcadorResponse>> SpTrae()
        {
            return await this._marcadorRepositorio.SpTrae();
        }
    }
}

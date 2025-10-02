using Asistencia.Abstractions.IApplication;
using Asistencia.Abstractions.IService;
using Asistencia.DTO.Common;
using Asistencia.DTO.Marcador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.Application.Marcador
{
    public class MarcadorApplication: IMarcadorApplication
    {
        private IMarcadorService _marcadorService;
        public MarcadorApplication(IMarcadorService marcadorService)
        {
            _marcadorService = marcadorService;
        }

        public async Task<ResultDTO<string>> SpElimina(string codigoMarcadorCliente, string codigoMarcadorProveedor)
        {
            return await this._marcadorService.SpElimina(codigoMarcadorCliente, codigoMarcadorProveedor);
        }

        public async Task<ResultDTO<string>> SpInserta(MarcadorRequest request)
        {
            return await this._marcadorService.SpInserta(request);
        }

        public async  Task<ResultDTO<MarcadorResponse>> SpTrae()
        {
            return await this._marcadorService.SpTrae();
        }
    }
}

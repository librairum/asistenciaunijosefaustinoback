using Asistencia.Abstractions.IApplication;
using Asistencia.Abstractions.IService;
using Asistencia.DTO.Autenticacion;
using Asistencia.DTO.Common;
using Asistencia.DTO.Permisos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.Application.Autenticacion
{
    public class AutenticacionApplication : IAutenticacionApplication
    {

        private IAutenticacionService _authService;
        public AutenticacionApplication(IAutenticacionService authService)
        {
            _authService = authService;
        }

        public async Task<ResultDTO<AccesoUsuarioResponse>> SpAccesoUsuario(AutenticacionRequest request)
        {
            return await this._authService.SpAccesoUsuario(request);
        }

    }
}

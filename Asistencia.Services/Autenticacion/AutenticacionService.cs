using Asistencia.Abstractions.IRepository;
using Asistencia.Abstractions.IService;
using Asistencia.DTO.Autenticacion;
using Asistencia.DTO.Common;
using Asistencia.DTO.Permisos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Asistencia.Services.Autenticacion
{
    public class AutenticacionService : IAutenticacionService
    {
        private IAutenticacionRepository _authRepositorio;
        public AutenticacionService(IAutenticacionRepository authRepositorio)
        {
            _authRepositorio = authRepositorio;
        }
        public  async Task<ResultDTO<AccesoUsuarioResponse>> SpAccesoUsuario(AutenticacionRequest request)
        {
            
            return await this._authRepositorio.SpAccesoUsuario(request);
        }

 
    }
}

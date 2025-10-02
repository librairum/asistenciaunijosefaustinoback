using Asistencia.DTO.Autenticacion;
using Asistencia.DTO.Common;
using Asistencia.DTO.Permisos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.Abstractions.IService
{
    public interface IAutenticacionService
    {
        public Task<ResultDTO<AccesoUsuarioResponse>> SpAccesoUsuario(AutenticacionRequest request);
 
    }
}

using Asistencia.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asistencia.DTO.Common;
using Asistencia.DTO.Autenticacion;
using Asistencia.DTO.Permisos;
namespace Asistencia.Abstractions.IRepository
{
    public interface IAutenticacionRepository
    {
        public Task<ResultDTO<AccesoUsuarioResponse>> SpAccesoUsuario(AutenticacionRequest request);
     

    }
}

using Asistencia.DTO.Autenticacion;
using Asistencia.DTO.Common;
using Asistencia.DTO.Permisos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.Abstractions.IApplication
{
    public interface IAutenticacionApplication
    {
        public Task<ResultDTO<AccesoUsuarioResponse>> SpAccesoUsuario(AutenticacionRequest request);


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.DTO.Usuario
{
    public  class UsuarioCreateRequest
    {
        public string Codigo { get; set; }
public string CuentaCod { get; set; }
public string NombreUsuario { get; set; }
public string ClaveUsuario { get; set; }
public string CodigoPerfil { get; set; }

        public string Codigoempresa { get; set; }


    }
}

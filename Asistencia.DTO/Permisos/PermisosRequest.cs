using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.DTO.Permisos
{
    public class PermisosRequest
    {
        /*
         @codmodulo char(2),  
@codigoperfil char(2),  
@xmlpermisos xml,  
@flag int output,  
        @mensaje varchar(200) output 
         */

        public string codmodulo { get; set; }
        public string codigoperfil { get; set; }
        public string xmlpermisos { get; set; }
        

    }
}

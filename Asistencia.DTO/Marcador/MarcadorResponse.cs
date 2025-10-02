using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.DTO.Marcador
{

    public class MarcadorResponse
    {
        /*
         Spu_Int_Trae_Marcadores
         */
        public string MarcadorProveedorCod { get; set; }
        public string MarcadorProveedorDesc { get; set; }
        public string MarcadorProveedorIp { get; set; }
        public string real_ip { get; set; }
        public string MarcadorClienteCod { get; set; }
        public string MarcadorDesc { get; set; }
        public string  MarcadorEstado { get; set; }
        public string MarcadorEstadoDesc { get; set; }
        public string sn { get; set; }
//        MarcadorProveedorCod MarcadorProveedorDesc   MarcadorProveedorIp real_ip MarcadorClienteCod MarcadorDesc    MarcadorEstado MarcadorEstadoDesc
//5	RELOJ DE ADMINISTRACION	192.168.1.153	190.223.42.110			 	
    }
}

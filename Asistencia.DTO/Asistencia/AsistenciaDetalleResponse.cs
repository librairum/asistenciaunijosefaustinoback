using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.DTO.Asistencia
{
    public class AsistenciaDetalleResponse
    {
        /*
         Item  ,Codigotrabajador,   
           , FechaMarcacion, ,,  
          ,  , , , ,   
         */
        public int Item { get;set; }
        public string FechaMarcacion { get;set; }
        public string Codigotrabajador { get; set; }
        public string NombreTrabajador { get; set; }

            public string DiaNombre { get; set; }
            public string HoraEntrada { get; set; }
            public string HoraSalida { get; set; }

        public double DiasFalta { get; set; }
        public string NHraDomPag { get; set; }

        public string NHraFerTra { get; set; }

        public string HturnoManu { get; set; }
        public string MinTardanza { get; set; }

        public string NHorExtr25 { get; set; }
        public string NHorExtr35 { get; set; }
        public string NHorExtr50 { get; set; }
        public string NHorExtr60 { get; set; }
        public string NHorExtr100Obrero { get; set; }
        public string NHorExtr100 { get; set; }
        public string NHorExtrDo { get; set; }

        public int Dias { get; set; }
            public string Horas25 { get; set; }
            public string Horas35 { get; set; }
            public string Horas60 { get; set; }
            public string Horas100 { get; set; }
        public string HorarioPersonalizado_Motivo { get; set; }
        public string HorarioPersonalizado { get; set; }


        public string HorasTrabajadas { get; set; }
        public string HorasExtrasTrabajadas { get; set; }



    }
}

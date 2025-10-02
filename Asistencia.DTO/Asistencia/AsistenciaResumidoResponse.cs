using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.DTO.Asistencia
{
    public class AsistenciaResumidoResponse
    {
        public int Item { get; set; }
        public string CodigoTrabajador { get; set; }
        public string Nombretrabajador { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string CodigoPlanilla { get; set; }
        public string NombrePlanilla { get; set; }
        public int Dias { get; set; }
        public string Horas25 { get; set; }
        public string Horas60 { get; set; }
        public string Horas100 { get; set; }

        //campos para exportacion de txt
        public double DiasFalta { get; set; }
        public string NHraDomPag { get; set; }

        public string NHraFerTra { get; set; }

        public string HturnoManu { get; set; }
        public string MinTardanza { get; set; }

        public string NHorExtr25 { get; set; }
        public string NHorExtr35 { get; set; }
        public string NHorExtr50 { get; set; }
        public string NHorExtr60 { get; set; }
        public string NHorExtr100 { get; set; }
        public string NHorExtr100Obrero { get; set; }

        public string HorasTrabajadas { get; set; }
        public string NHorExtrDo { get; set; }

        public string HorasHorario { get; set; }
        public string HorasExtrasTotales {get;set;}

        public int DiasDescanso { get; set; }
    }
}

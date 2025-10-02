using Asistencia.DTO.Common;
using Asistencia.DTO.Horario;
using Asistencia.DTO.MotivoHorario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.Abstractions.IApplication
{
    public interface IMotivoHorarioApplication
    {

        public Task<ResultDTO<MotivoHorarioResponse>> SpTraeHorarios(string EmpresaCod);

        
        public Task<ResultDTO<string>> SpInserta(MotivoHorarioRequest entidad);
        public Task<ResultDTO<string>> SpActualiza(MotivoHorarioRequest entidad);
        public Task<ResultDTO<string>> SpEliminar(string codigoEmpresa, string codigoMotivo);

        /*
         Spu_Int_Ins_MotivoHorario  
@EmpresaCod char(2),
@IdMotivo char(2),  
@Descripcion varchar(100),  
@flag int output,  
@mensaje varchar(100) output  
         */
        /*
         Spu_Int_Upd_MotivoHorario   
@EmpresaCod char(2),
@IdMotivo char(2),    
@Descripcion varchar(100),    
@flag int output,    
@mensaje varchar(100) output 
         */

        /*
         Spu_Int_Del_MotivoHorario
@EmpresaCod char(2),
@IdMotivo char(2),    
@flag int output,    
@mensaje varchar(100) output    
         */



    }
}

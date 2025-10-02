using Asistencia.Abstractions.IRepository;
using Asistencia.DTO.Common;
using Asistencia.DTO.Horario;
using Asistencia.DTO.MotivoHorario;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;
namespace Asistencia.Repository.MotivoHorario
{
    public class MotivoHorarioRepository : IMotivoHorarioRepository
    {
        private string _connectionString = "";
        public MotivoHorarioRepository(IConfiguration configuracion)
        {
            this._connectionString = configuracion.GetConnectionString("conexion");
        }
        public async Task<ResultDTO<string>> SpActualiza(MotivoHorarioRequest entidad)
        {
            ResultDTO<string> result = new ResultDTO<string>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Int_Upd_MotivoHorario",cn);
                
                cmd.Parameters.AddWithValue("@EmpresaCod", entidad.EmpresaCod);
                cmd.Parameters.AddWithValue("@IdMotivo", entidad.IdMotivo);
                cmd.Parameters.AddWithValue("@Descripcion", entidad.Descripcion);
                cmd.Parameters.AddWithValue("@flagCalculaTiempo", entidad.flagCalculaTiempo);
                var parFlag = cmd.Parameters.Add("@flag", System.Data.SqlDbType.Int);
                parFlag.Direction = System.Data.ParameterDirection.Output;

                var parMensaje = cmd.Parameters.Add("@mensaje", System.Data.SqlDbType.VarChar,200);
                parMensaje.Direction = System.Data.ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync(); 
                cn.Close();
                result.Item = entidad.IdMotivo;
                result.IsSuccess = parFlag.Value.ToString() == "1" ? true : false;
                result.Message = parMensaje.Value.ToString();

            }
            catch (Exception ex) {
                result.MessageException = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        public async Task<ResultDTO<string>> SpEliminar(string EmpresaCod, string IdMotivo)
        {
            ResultDTO<string> result = new ResultDTO<string>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Int_Del_MotivoHorario", cn);
                cmd.Parameters.AddWithValue("@EmpresaCod", EmpresaCod);
                cmd.Parameters.AddWithValue("@IdMotivo", IdMotivo);
                cmd.CommandType = CommandType.StoredProcedure;
                var parflag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                parflag.Direction = ParameterDirection.Output;
                var parMensaje = cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200);
                parMensaje.Direction = ParameterDirection.Output;
                cn.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cn.Close();
                result.Item = IdMotivo;
                result.IsSuccess = true;
                result.Message = parMensaje.Value.ToString();
            }
            catch (Exception ex) {
                result.MessageException = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        public async Task<ResultDTO<string>> SpInserta(MotivoHorarioRequest entidad)
        {
            ResultDTO<string> result = new ResultDTO<string>();

            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Int_Ins_MotivoHorario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpresaCod", entidad.EmpresaCod);
                cmd.Parameters.AddWithValue("@IdMotivo", entidad.IdMotivo);
                cmd.Parameters.AddWithValue("@Descripcion", entidad.Descripcion);
                cmd.Parameters.AddWithValue("@flagCalculaTiempo", entidad.flagCalculaTiempo);
                var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                parFlag.Direction = ParameterDirection.Output;

                var parMensaje = cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200);
                parMensaje.Direction = ParameterDirection.Output;

                cn.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cn.Close();

                result.Item = entidad.IdMotivo;
                result.IsSuccess = parFlag.Value.ToString() == "1" ? true : false;
                result.Message = parMensaje.Value.ToString();

            }
            catch (Exception ex) {
                result.IsSuccess = false;
                result.MessageException = ex.Message;
            }
            return result;
        }

        public async Task<ResultDTO<MotivoHorarioResponse>> SpTraeHorarios(string EmpresaCod)
        {
            ResultDTO<MotivoHorarioResponse> res = new ResultDTO<MotivoHorarioResponse>();
            List<MotivoHorarioResponse> lista = new List<MotivoHorarioResponse>();

            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                
                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("@EmpresaCod", EmpresaCod);
                lista = (List<MotivoHorarioResponse>)await cn.QueryAsync<MotivoHorarioResponse>("Spu_Int_Trae_MotivosHorario", parametros,
                    commandType: CommandType.StoredProcedure);
                res.IsSuccess = lista.Count > 0 ? true : false;
                res.Message = lista.Count > 0 ? "Informacion encontrada" : "No se encuentra informacion";
                res.Data = lista.ToList();
            }
            catch (Exception ex) {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            return res;
        }
    }
}

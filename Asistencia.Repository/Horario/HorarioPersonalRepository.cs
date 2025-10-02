using Asistencia.Abstractions.IRepository;
using Asistencia.DTO.Common;
using Asistencia.DTO.Horario;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using Asistencia.DTO.HorarioPersonal;
namespace Asistencia.Repository.Horario
{
    public class HorarioPersonalRepository : IHorarioPersonalRepository
    {

        private string _connectionString = "";
        public HorarioPersonalRepository(IConfiguration configuracion)
        {
            this._connectionString = configuracion.GetConnectionString("conexion");
        }
        public async Task<ResultDTO<string>> SpActualiza(HorarioPersonalRequest entidad)
        {
            ResultDTO<string> result = new ResultDTO<string>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Int_Upd_HorarioPersonal", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpresaCod", entidad.EmpresaCod);
                cmd.Parameters.AddWithValue("@IdEmpleado", entidad.IdEmpleado);
                //cmd.Parameters.AddWithValue("@tipodocumento", entidad.tipodocumento);
                cmd.Parameters.AddWithValue("@dia", entidad.dia);
                cmd.Parameters.AddWithValue("@IdMotivo", entidad.IdMotivo);
                cmd.Parameters.AddWithValue("@horaingreso", entidad.horaingreso);
                cmd.Parameters.AddWithValue("@horasalida", entidad.horasalida);
                var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                parFlag.Direction = ParameterDirection.Output;

                var parMensaje = cmd.Parameters.Add("@mensaje", SqlDbType.VarChar,200);
                parMensaje.Direction = ParameterDirection.Output;

                cn.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cn.Close();

                result.Item = entidad.IdEmpleado.ToString();
                result.IsSuccess = parFlag.Value.ToString() == "1" ? true : false;
                result.Message = parMensaje.Value.ToString();
            }
            catch (Exception ex) {

                result.MessageException = ex.Message;
                result.IsSuccess = false;
            }

            return result;
        }

        public async Task<ResultDTO<string>> SpInserta(HorarioPersonalRequest entidad)
        {
            ResultDTO<string> result = new ResultDTO<string>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Int_Ins_HorarioPersonal", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpresaCod", entidad.EmpresaCod);
                cmd.Parameters.AddWithValue("@IdEmpleado", entidad.IdEmpleado);               
                cmd.Parameters.AddWithValue("@dia", entidad.dia);
                cmd.Parameters.AddWithValue("@IdMotivo", entidad.IdMotivo);
                cmd.Parameters.AddWithValue("@horaingreso", entidad.horaingreso);
                cmd.Parameters.AddWithValue("@horasalida", entidad.horasalida);
                var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                parFlag.Direction = ParameterDirection.Output;

                var parMensaje = cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200);
                parMensaje.Direction = ParameterDirection.Output;

                cn.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cn.Close();

                result.Item = entidad.IdEmpleado.ToString();
                result.IsSuccess = parFlag.Value.ToString() == "1" ? true : false;
                result.Message = parMensaje.Value.ToString();
            }
            catch (Exception ex)
            {

                result.MessageException = ex.Message;
                result.IsSuccess = false;
            }

            return result;
        }

        public async Task<ResultDTO<HorarioGeneralResponse>> SpTraeHorarios(string EmpresaCod)
        {
            ResultDTO<HorarioGeneralResponse> result = new ResultDTO<HorarioGeneralResponse>();
            List<HorarioGeneralResponse> lista = new List<HorarioGeneralResponse>();
            try {
                SqlConnection cn = new SqlConnection(_connectionString);
                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("@EmpresaCod", EmpresaCod);
                lista = (List<HorarioGeneralResponse>)await cn.QueryAsync<HorarioGeneralResponse>("Spu_Int_Trae_HorariosGeneral",
                    parametros, commandType: System.Data.CommandType.StoredProcedure);
                result.IsSuccess = lista.Count > 0 ? true : false;
                result.Message = lista.Count > 0 ? "Informacion encontrada" : "Informacion no encontrado";
                result.Data = lista.ToList();            
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.MessageException = ex.Message;
            }
            return result;
        }

        public async Task<ResultDTO<HorarioPersonalResponse>> SpTraeHorarioDet(string EmpresaCod, string idpersonal, string dia)
        {
            ResultDTO<HorarioPersonalResponse> result = new ResultDTO<HorarioPersonalResponse>();
            List<HorarioPersonalResponse> lista = new List<HorarioPersonalResponse>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("@EmpresaCod", EmpresaCod);
                parametros.Add("@IdEmpleado", idpersonal);
                parametros.Add("@dia", dia);
                lista = (List<HorarioPersonalResponse>)await cn.QueryAsync<HorarioPersonalResponse>("Spu_Int_Trae_HorarioPersonal",
                    parametros, commandType: System.Data.CommandType.StoredProcedure);
                result.IsSuccess = lista.Count > 0 ? true : false;
                result.Message = lista.Count > 0 ? "Informacion encontrada" : "informacion no encontrdo";
                result.Data = lista.ToList();

            }
            catch (Exception ex) {
                result.IsSuccess = false;
                result.MessageException = ex.Message;
            }
            return result;
        }

        public async Task<ResultDTO<string>> SpActualizaHorariosMasivo(HorarioMasivoRequest entidad)
        {

            ResultDTO<string> result = new ResultDTO<string>();

            try {
                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Int_Upd_HorariosPersonalMasivo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@xmlhorarios", entidad.xmlhorarios);

                var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                parFlag.Direction = ParameterDirection.Output;

                var parMensaje = cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200);
                parMensaje.Direction = ParameterDirection.Output;

                cn.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cn.Close();
                result.Item = "1";
                result.IsSuccess = parFlag.Value.ToString() == "1" ? true : false;
                result.Message = parMensaje.Value.ToString();

            }
            catch (Exception ex)
            {
                result.MessageException = ex.Message;
                result.IsSuccess = false;
            }
            return result;

        }

        public async Task<ResultDTO<string>> SpActualizaHorarioDinamico(HorarioPersonalRequest entidad)
        {
            ResultDTO<string> result = new ResultDTO<string>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Int_Upd_HorarioPersonalDinamico", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpresaCod", entidad.EmpresaCod);
                cmd.Parameters.AddWithValue("@IdEmpleado", entidad.IdEmpleado);
                cmd.Parameters.AddWithValue("@dia", entidad.dia);
                cmd.Parameters.AddWithValue("@IdMotivo", entidad.IdMotivo);
                cmd.Parameters.AddWithValue("@horaingreso", entidad.horaingreso);
                cmd.Parameters.AddWithValue("@horasalida", entidad.horasalida);
                var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                parFlag.Direction = ParameterDirection.Output;

                var parMensaje = cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200);
                parMensaje.Direction = ParameterDirection.Output;


                cn.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cn.Close();

                result.Item = entidad.IdEmpleado.ToString();
                result.IsSuccess = parFlag.Value.ToString() == "1" ? true : false;
                result.Message = parMensaje.Value.ToString();
            }
            catch (Exception ex) {
                result.MessageException = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }
    }
}

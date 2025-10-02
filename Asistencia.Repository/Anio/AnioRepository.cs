using Asistencia.Abstractions.IRepository;
using Asistencia.Abstractions.IService;
using Asistencia.DTO.Anio;
using Asistencia.DTO.Common;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Azure.Core;
using Asistencia.DTO.Usuario;
using Dapper;
namespace Asistencia.Repository.Anio
{
    public class AnioRepository : IAnioRepository
    {

        private string _connectionString = "";

        public AnioRepository(IConfiguration configuracion)
        {
            this._connectionString = configuracion.GetConnectionString("conexion");
        }
        public async Task<ResultDTO<string>> SpActualizaAnio(AnioRequest request)
        {
            ResultDTO<string> result = new ResultDTO<string>();
            try {
                SqlConnection cn = new SqlConnection(this._connectionString);
                string nombreprocedimiento = "Spu_Int_Upd_Anio";
                SqlCommand cmd = new SqlCommand(nombreprocedimiento, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Pla61Codigo", request.Pla61Codigo);
                cmd.Parameters.AddWithValue("@Pla61Descripcion", request.Pla61Descripcion);
                var parFlag = cmd.Parameters.Add("@flag", System.Data.SqlDbType.Int);
                parFlag.Direction = System.Data.ParameterDirection.Output;

                var parMensaje = cmd.Parameters.Add("@mensaje", System.Data.SqlDbType.VarChar, 200);
                parMensaje.Direction = System.Data.ParameterDirection.Output;

                cn.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cn.Close();

                result.Item = request.Pla61Codigo;
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

        public async Task<ResultDTO<string>> SpEliminaAnio(string codigo)
        {
            ResultDTO<string> result = new ResultDTO<string>();
            try {
                SqlConnection cn = new SqlConnection(this._connectionString);
                string nombreprocedimiento = "Spu_Int_Del_Anio";
                SqlCommand cmd = new SqlCommand(nombreprocedimiento, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Pla61Codigo", codigo);
                
                var parFlag = cmd.Parameters.Add("@flag", System.Data.SqlDbType.Int);
                parFlag.Direction = System.Data.ParameterDirection.Output;

                var parMensaje = cmd.Parameters.Add("@mensaje", System.Data.SqlDbType.VarChar, 200);
                parMensaje.Direction = System.Data.ParameterDirection.Output;

                cn.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cn.Close();

                result.Item = codigo;
                result.IsSuccess = parFlag.Value.ToString() == "1" ? true : false;
                result.Message = parMensaje.Value.ToString();
            }
            catch(Exception ex) {
                result.MessageException = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        public async  Task<ResultDTO<string>> SpInsertaAnio(AnioRequest request)
        {
            ResultDTO<string> result = new ResultDTO<string>();
            try
            {
                SqlConnection cn = new SqlConnection(this._connectionString);
                string nombreprocedimiento = "Spu_Int_Ins_Anio";
                SqlCommand cmd = new SqlCommand(nombreprocedimiento, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Pla61Codigo", request.Pla61Codigo);
                cmd.Parameters.AddWithValue("@Pla61Descripcion", request.Pla61Descripcion);

                var parFlag = cmd.Parameters.Add("@flag", System.Data.SqlDbType.Int);
                parFlag.Direction = System.Data.ParameterDirection.Output;

                var parMensaje = cmd.Parameters.Add("@mensaje", System.Data.SqlDbType.VarChar, 200);
                parMensaje.Direction = System.Data.ParameterDirection.Output;

                cn.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cn.Close();

                result.Item = request.Pla61Codigo;
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

        public async  Task<ResultDTO<AnioResponse>> SpTraeAnio()
        {
            ResultDTO<AnioResponse> res = new ResultDTO<AnioResponse>();
            List<AnioResponse> lista = new List<AnioResponse>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                DynamicParameters parametros = new DynamicParameters();
                //agregar parametros
                // parametros.add("@flag", flag)
                lista = (List<AnioResponse>)await cn.QueryAsync<AnioResponse>("Spu_Int_Trae_Anio",
                    parametros, commandType: System.Data.CommandType.StoredProcedure);
                res.IsSuccess = lista.Count > 0 ? true : false;
                res.Message = lista.Count > 0 ? "Informacion encontrada" : "No se encuentra informacion";
                res.Data = lista.ToList();
                //res.Total = lista.Count >0 ? lista[0].

            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            //Spu_Int_Trae_Usuarios
            return res;
        }

        public async Task<ResultDTO<MesResponse>> SpTraeMeses()
        {
            ResultDTO<MesResponse> res = new ResultDTO<MesResponse>();
            List<MesResponse> lista = new List<MesResponse>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                DynamicParameters parametros = new DynamicParameters();
                //agregar parametros
                // parametros.add("@flag", flag)
                lista = (List<MesResponse>)await cn.QueryAsync<MesResponse>("Spu_Pla_Trae_Meses",
                    parametros, commandType: System.Data.CommandType.StoredProcedure);
                res.IsSuccess = lista.Count > 0 ? true : false;
                res.Message = lista.Count > 0 ? "Informacion encontrada" : "No se encuentra informacion";
                res.Data = lista.ToList();
                //res.Total = lista.Count >0 ? lista[0].

            }
            catch (Exception ex)
            {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            //Spu_Int_Trae_Usuarios
            return res;
        }
    }
}

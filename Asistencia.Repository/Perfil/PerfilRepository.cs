using Asistencia.Abstractions.IRepository;
using Asistencia.DTO.Anio;
using Asistencia.DTO.Common;
using Asistencia.DTO.Perfil;
using Azure.Core;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.Repository.Perfil
{
    public class PerfilRepository : IPerfilRepository
    {

        private string _connectionString = "";
        public PerfilRepository(IConfiguration configuracion)
        {
            this._connectionString = configuracion.GetConnectionString("conexion");
        }
        public async Task<ResultDTO<string>> SpActualiza(PerfilRequest request)
        {
            ResultDTO<string> result = new ResultDTO<string>();
            try
            {
                SqlConnection cn = new SqlConnection(this._connectionString);
                string nombreprocedimiento = "Spu_Int_Upd_Perfil";
                SqlCommand cmd = new SqlCommand(nombreprocedimiento, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", request.codigo);
                cmd.Parameters.AddWithValue("@nombre", request.nombre);
                cmd.Parameters.AddWithValue("@descripcion", request.descripcion);
                var parFlag = cmd.Parameters.Add("@flag", System.Data.SqlDbType.Int);
                parFlag.Direction = System.Data.ParameterDirection.Output;

                var parMensaje = cmd.Parameters.Add("@mensaje", System.Data.SqlDbType.VarChar, 200);
                parMensaje.Direction = System.Data.ParameterDirection.Output;

                cn.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cn.Close();

                result.Item = request.codigo;
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

        public async Task<ResultDTO<string>> SpElimina(string codigo)
        {
            ResultDTO<string> result = new ResultDTO<string>();
            try
            {
                SqlConnection cn = new SqlConnection(this._connectionString);
                string nombreprocedimiento = "Spu_Int_Del_Perfil";
                SqlCommand cmd = new SqlCommand(nombreprocedimiento, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", codigo);
                
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
            catch (Exception ex)
            {
                result.MessageException = ex.Message;
                result.IsSuccess = false;

            }
            return result;
        }

        public async Task<ResultDTO<string>> SpInserta(PerfilRequest request)
        {
            ResultDTO<string> result = new ResultDTO<string>();
            try
            {
                SqlConnection cn = new SqlConnection(this._connectionString);
                string nombreprocedimiento = "Spu_Int_Ins_Perfil";
                SqlCommand cmd = new SqlCommand(nombreprocedimiento, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", request.codigo);
                cmd.Parameters.AddWithValue("@nombre", request.nombre);
                cmd.Parameters.AddWithValue("@descripcion", request.descripcion);
                var parFlag = cmd.Parameters.Add("@flag", System.Data.SqlDbType.Int);
                parFlag.Direction = System.Data.ParameterDirection.Output;

                var parMensaje = cmd.Parameters.Add("@mensaje", System.Data.SqlDbType.VarChar, 200);
                parMensaje.Direction = System.Data.ParameterDirection.Output;

                cn.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cn.Close();

                result.Item = request.codigo;
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

        public async Task<ResultDTO<PerfilResponse>> SpTraePerfil()
        {
            ResultDTO<PerfilResponse> res = new ResultDTO<PerfilResponse>();
            List<PerfilResponse> lista = new List<PerfilResponse>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                DynamicParameters parametros = new DynamicParameters();
                //agregar parametros
                // parametros.add("@flag", flag)
                lista = (List<PerfilResponse>)await cn.QueryAsync<PerfilResponse>("Spu_Int_Trae_Perfiles",
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

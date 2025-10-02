using Asistencia.Abstractions.IRepository;
using Asistencia.DTO.Common;
using Asistencia.DTO.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.ComponentModel;
using Azure.Core;

namespace Asistencia.Repository.Usuario
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string _connectionString = "";

        public UsuarioRepository(IConfiguration configuracion)
        {
            _connectionString = configuracion.GetConnectionString("conexion");
        }
        public async Task<ResultDTO<string>> SpActualizarUsuario(UsuarioCreateRequest request)
        {
            ResultDTO<string> result = new ResultDTO<string>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Int_Upd_Usuario", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", request.Codigo);
                cmd.Parameters.AddWithValue("@cuentacod", request.CuentaCod);
                cmd.Parameters.AddWithValue("@claveUsuario", request.ClaveUsuario);
                cmd.Parameters.AddWithValue("@codigoperfil", request.CodigoPerfil);
                cmd.Parameters.AddWithValue("@nombreusuario", request.NombreUsuario);
                var parFlag = cmd.Parameters.Add("@flag", System.Data.SqlDbType.Int);
                parFlag.Direction = System.Data.ParameterDirection.Output;
                
                var parMensaje = cmd.Parameters.Add("@mensaje", System.Data.SqlDbType.VarChar,200);
                parMensaje.Direction = System.Data.ParameterDirection.Output;
                cn.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cn.Close();

                result.Item = request.Codigo;
                result.IsSuccess = parFlag.Value.ToString() == "1" ? true : false;
                result.Message = parMensaje.Value.ToString();

                //cmd.Parameters.AddWithValue("@flag", request.Codigo);
                //cmd.Parameters.AddWithValue("@mensaje", request.Codigo);

            }
            catch (Exception ex) {
                result.MessageException = ex.Message;
                result.IsSuccess = false;
            }
            return result;

        }

        public async Task<ResultDTO<string>> SpEliminaUsuario(string  codigo, string cuentacod, string empresacod)
        {
            ResultDTO<string> result = new ResultDTO<string>();
            try {
                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Int_Del_Usuario", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", codigo);
                cmd.Parameters.AddWithValue("@cuentacod", cuentacod);
                //@empresacod varchar(5)
                cmd.Parameters.AddWithValue("@empresacod", empresacod);
                var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                parFlag.Direction = ParameterDirection.Output;
                var parMensaje = cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200);
                parMensaje.Direction = ParameterDirection.Output;

                cn.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cn.Close();
                result.Item = codigo;
                result.IsSuccess = parFlag.Value.ToString() == "1" ? true : false;
                result.Message = parMensaje.Value.ToString();


            } catch (Exception ex){
                result.MessageException = ex.Message;
                result.IsSuccess = false;
            }
          
            return result;
        }

        public async Task<ResultDTO<string>> SpInsertaUsuario(UsuarioCreateRequest request)
        {
            ResultDTO<string> result = new ResultDTO<string>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Int_Ins_Usuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigousuario", request.Codigo);
                cmd.Parameters.AddWithValue("@cuentacod", request.CuentaCod);
                cmd.Parameters.AddWithValue("@nombreusuario", request.NombreUsuario);
                cmd.Parameters.AddWithValue("@claveusuario", request.ClaveUsuario);
                cmd.Parameters.AddWithValue("@codigoperfil", request.CodigoPerfil);
                cmd.Parameters.AddWithValue("@empresacod", request.Codigoempresa);

                var parFlag = cmd.Parameters.Add("@flag", SqlDbType.Int);
                parFlag.Direction = ParameterDirection.Output;
                var parMensaje = cmd.Parameters.Add("@mensaje", SqlDbType.VarChar, 200);
                parMensaje.Direction = ParameterDirection.Output;
                cn.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cn.Close();

                result.Item = request.Codigo;
                result.IsSuccess = parFlag.Value.ToString() == "1" ? true: false;
                result.Message = parMensaje.Value.ToString();
            }
            catch (Exception ex) {
                result.Message = ex.Message;
                result.IsSuccess = false;
            }
            //throw new NotImplementedException();

          
            return result;
        }

        public async Task<ResultDTO<UsuarioListResponse>> SpListaUsuaurio()
        {

            /*
             Spu_Int_Trae_Usuarios
             */
            ResultDTO<UsuarioListResponse> res = new ResultDTO<UsuarioListResponse> ();
            List<UsuarioListResponse> lista = new List<UsuarioListResponse>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                DynamicParameters parametros = new DynamicParameters();
                //agregar parametros
                // parametros.add("@flag", flag)
                lista = (List<UsuarioListResponse>)await cn.QueryAsync<UsuarioListResponse>("Spu_Int_Trae_Usuarios",
                    parametros, commandType: System.Data.CommandType.StoredProcedure);
                res.IsSuccess = lista.Count > 0 ? true : false;
                res.Message = lista.Count > 0 ? "Informacion encontrada" : "No se encuentra informacion";
                res.Data = lista.ToList();
                //res.Total = lista.Count >0 ? lista[0].

            }catch (Exception ex) {
                res.IsSuccess = false;
                res.MessageException = ex.Message;
            }
            //Spu_Int_Trae_Usuarios
            return res;
        }
    }
}

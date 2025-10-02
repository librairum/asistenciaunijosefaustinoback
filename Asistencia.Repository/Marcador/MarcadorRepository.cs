using Asistencia.Abstractions.IRepository;
using Asistencia.DTO.Common;
using Asistencia.DTO.Marcador;
using Asistencia.DTO.Usuario;
using Azure.Core;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asistencia.Repository.Marcador
{
    public class MarcadorRepository:IMarcadorRepository
    {
        private string _connectionString = "";
        public MarcadorRepository(IConfiguration configuracion)
        {
            this._connectionString = configuracion.GetConnectionString("conexion");
        }

        public async Task<ResultDTO<string>> SpElimina(string codigoMarcadorCliente, string codigoMarcadorProveedor)
        {
            ResultDTO<string> result = new ResultDTO<string>();
            try
            {

          
                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Int_Del_Marcadores", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MarcadorClienteCod", codigoMarcadorCliente);
                cmd.Parameters.AddWithValue("@MarcadorProveedorCod", codigoMarcadorProveedor);
                
                var parFlag = cmd.Parameters.Add("@flag", System.Data.SqlDbType.Int);
                parFlag.Direction = System.Data.ParameterDirection.Output;

                var parMensaje = cmd.Parameters.Add("@mensaje", System.Data.SqlDbType.VarChar, 200);
                parMensaje.Direction = System.Data.ParameterDirection.Output;
                cn.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cn.Close();

                result.Item = codigoMarcadorCliente;
                result.IsSuccess = parFlag.Value.ToString() == "1" ? true : false;
                result.Message = parMensaje.Value.ToString();

                //cmd.Parameters.AddWithValue("@flag", request.Codigo);
                //cmd.Parameters.AddWithValue("@mensaje", request.Codigo);

            }
            catch (Exception ex)
            {
                result.MessageException = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        public  async Task<ResultDTO<string>> SpInserta(MarcadorRequest request)
        {
            ResultDTO<string> result = new ResultDTO<string>();
            try
            {
              

                SqlConnection cn = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("Spu_Int_Ins_Marcadores", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MarcadorClienteCod", request.MarcadorClienteCod);
                cmd.Parameters.AddWithValue("@MarcadorProveedorCod", request.MarcadorProveedorCod);
                cmd.Parameters.AddWithValue("@MarcadorDesc", request.MarcadorDesc);
                cmd.Parameters.AddWithValue("@MarcadorEstado", request.MarcadorEstado);

                var parFlag = cmd.Parameters.Add("@flag", System.Data.SqlDbType.Int);
                parFlag.Direction = System.Data.ParameterDirection.Output;

                var parMensaje = cmd.Parameters.Add("@mensaje", System.Data.SqlDbType.VarChar, 200);
                parMensaje.Direction = System.Data.ParameterDirection.Output;
                cn.Open();
                var respuesta = await cmd.ExecuteNonQueryAsync();
                cn.Close();

                result.Item = request.MarcadorClienteCod;
                result.IsSuccess = parFlag.Value.ToString() == "1" ? true : false;
                result.Message = parMensaje.Value.ToString();

                //cmd.Parameters.AddWithValue("@flag", request.Codigo);
                //cmd.Parameters.AddWithValue("@mensaje", request.Codigo);

            }
            catch (Exception ex)
            {
                result.MessageException = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }

        public async Task<ResultDTO<MarcadorResponse>> SpTrae()
        {
            ResultDTO<MarcadorResponse> res = new ResultDTO<MarcadorResponse>();
            List<MarcadorResponse> lista = new List<MarcadorResponse>();
            try
            {
                SqlConnection cn = new SqlConnection(_connectionString);
                DynamicParameters parametros = new DynamicParameters();
                //agregar parametros
                // parametros.add("@flag", flag)
                lista = (List<MarcadorResponse>)await cn.QueryAsync<MarcadorResponse>("Spu_Int_Trae_Marcadores",
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
            
            return res;
        }
    }
}

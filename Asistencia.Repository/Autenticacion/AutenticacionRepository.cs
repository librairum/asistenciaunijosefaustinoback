using Asistencia.Abstractions.IRepository;
using Asistencia.DTO.Autenticacion;
using Asistencia.DTO.Common;
using Asistencia.DTO.Permisos;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;


namespace Asistencia.Repository.Autenticacion
{
    public class AutenticacionRepository : IAutenticacionRepository
    {
        private string _connectionString = "";
        public AutenticacionRepository(IConfiguration configuration)
        {
            this._connectionString = configuration.GetConnectionString("conexion");
        }

        

        public async Task<ResultDTO<AccesoUsuarioResponse>> SpAccesoUsuario(AutenticacionRequest request)
        {
            ResultDTO<AccesoUsuarioResponse> res = new ResultDTO<AccesoUsuarioResponse>();
            List<AccesoUsuarioResponse> lista = new List<AccesoUsuarioResponse>();
            try
            {
                SqlConnection cn = new SqlConnection(this._connectionString);
                DynamicParameters parametros = new DynamicParameters();
                parametros.Add("@NombreUsuario", request.nombreusuario);
                parametros.Add("@ClaveUsuario", request.claveusuario);
                parametros.Add("@codigoEmpresa", request.codigoempresa);

                lista = (List<AccesoUsuarioResponse>)await cn.QueryAsync<AccesoUsuarioResponse>("Spu_Seg_Trae_Autenticacion_Usuario",
                    parametros, commandType: System.Data.CommandType.StoredProcedure);
                res.IsSuccess = lista.Count > 0 ? true : false;
                res.Message = lista.Count > 0 ? "Informacion encontrada" : "No se encontro informacion";
                res.Data = lista.ToList();
                res.Total = lista.Count;

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

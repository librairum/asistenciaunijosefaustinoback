using Asistencia.Repository.Usuario;
using Asistencia.Abstractions.IRepository;
using Microsoft.Extensions.DependencyInjection;
using Asistencia.Repository.Autenticacion;
using Asistencia.Repository.Anio;
using Asistencia.Repository.Marcador;
using Asistencia.Repository.Permisos;
using Asistencia.Repository.Perfil;
using Asistencia.Repository.Asistencia;
using Asistencia.Repository.MotivoHorario;
using Asistencia.Repository.Horario;

namespace Asistencia.Repository
{
    public static class RepositoryServiceRegister
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IAutenticacionRepository, AutenticacionRepository>();
            services.AddScoped<IAnioRepository, AnioRepository>();
            services.AddScoped<IMarcadorRepository, MarcadorRepository>();
            services.AddScoped<IPermisosRepository, PermisosRepository>();
            services.AddScoped<IPerfilRepository, PerfilRepository>();
            services.AddScoped<IAsistenciaRepository, AsistenciaRepository>();
            services.AddScoped<IMotivoHorarioRepository, MotivoHorarioRepository>();
            services.AddScoped<IHorarioPersonalRepository, HorarioPersonalRepository>();
            //agregar otras lineas de services segun se crear mas clase reporsitory 
            return services;
        }
    }
}

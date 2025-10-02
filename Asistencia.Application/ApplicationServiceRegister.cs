using Microsoft.Extensions.DependencyInjection;
using Asistencia.Abstractions.IApplication;
using Asistencia.Application.Usuario;
using Asistencia.Application.Autenticacion;
using Asistencia.Application.Anio;
using Asistencia.Application.Marcador;
using Asistencia.Application.Permisos;
using Asistencia.Application.Perfil;
using Asistencia.Application.Asistencia;
using Asistencia.Application.MotivoHorario;
using Asistencia.Application.Horario;

namespace Asistencia.Application
{
    public static class ApplicationServiceRegister
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
           services.AddScoped<IUsuarioApplication, UsuarioApplication>();
            services.AddScoped<IAutenticacionApplication, AutenticacionApplication>();
            services.AddScoped<IAnioApplication, AnioApplication>();
            services.AddScoped<IMarcadorApplication, MarcadorApplication>();
            services.AddScoped<IPermisosApplication, PermisosApplication>();
            services.AddScoped<IPerfilApplication, PerfilApplication>();
            services.AddScoped<IAsistenciaApplication, AsistenciaApplication>();
            services.AddScoped<IMotivoHorarioApplication, MotivoHorarioApplication>();
            services.AddScoped<IHorarioPersonalApplication, HorarioPersonalApplication>();
            //agregar mas clases de aplicacion
            return services;
        }
    }
}

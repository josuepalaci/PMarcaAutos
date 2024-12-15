using Api.Handlers.Interfaces;
using Api.Handlers.MarcaAutos;
using Api.Persistencia.Interfaces;
using Api.Persistencia.Repositories;

namespace Api
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddApi(this IServiceCollection services)
        {

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // inyectar dependencias de repositorios
            services.AddScoped<IMarcaAutosRepository, MarcaAutosRepository>();

            // inyectar dependencias de handlers
            services.AddScoped<IMarcaAutosHandler, MarcaAutosHandler>();

            return services;
        }




    }
}

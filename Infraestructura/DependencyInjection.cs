using Infraestructura.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructura
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructura(this IServiceCollection services,
            IConfiguration configuration)
        {
            // obtener la cadena de conexion de la variable de entorno o de appsettings.json
            var connectionString = configuration["DB_CONNECTION_STRING"] ??
                                   configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AutosDbContext>(options => options.UseNpgsql(connectionString));

            return services;
        }
    }
}

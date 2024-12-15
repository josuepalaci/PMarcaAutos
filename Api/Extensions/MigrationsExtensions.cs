using Infraestructura.Context;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions;

public static class MigrationsExtensions
{
    public static void ApplyMigrations(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContextInfraestructure = scope.ServiceProvider.GetRequiredService<AutosDbContext>();
        if ( dbContextInfraestructure.Database.GetPendingMigrations().Any() )
        {
            dbContextInfraestructure.Database.Migrate();
        }

    }

}

using Infraestructura.Models;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Context;

public class AutosDbContext(DbContextOptions<AutosDbContext> options) : DbContext(options)
{

    public DbSet<MarcaAutos> MarcasAutos { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AutosDbContext).Assembly);
    }


}

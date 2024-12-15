using Infraestructura.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Configurations;

public class MarcaAutosConfigurations : IEntityTypeConfiguration<MarcaAutos>
{
    public void Configure(EntityTypeBuilder<MarcaAutos> builder)
    {

        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id).ValueGeneratedOnAdd();
        builder.Property(m => m.Nombre).HasMaxLength(250).IsRequired();
        builder.HasIndex(m => m.Nombre).IsUnique();

        builder.HasData(
            new MarcaAutos { Id = 1, Nombre = "Subaru" },
            new MarcaAutos { Id = 2, Nombre = "Toyota" },
            new MarcaAutos { Id = 3, Nombre = "Chevrolet" },
            new MarcaAutos { Id = 4, Nombre = "Ford" },
            new MarcaAutos { Id = 5, Nombre = "Nissan" },
            new MarcaAutos { Id = 6, Nombre = "Hyundai" }
        );

    }
}

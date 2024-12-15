using Api;
using Api.Extensions;
using Infraestructura;

var builder = WebApplication.CreateBuilder(args);

// Add inyeccion de dependencias de los proyectos
builder.Services
    // se trabaja la logica de negocio en un proyecto diferente por lo que se debe agregar la inyeccion de dependencias
    .AddApi()
    // se trabaja la base de datos en un proyecto diferente por lo que se debe agregar la inyeccion de dependencias
    .AddInfraestructura(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if ( app.Environment.IsDevelopment() )
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // se aplica las migraciones de la base de datos en el ambiente de desarrollo
    // se verifica si hay migraciones pendientes y se aplican
    // para un mayor control de la aplicacion de las migraciones se puede comentar esta linea
    app.ApplyMigrations();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

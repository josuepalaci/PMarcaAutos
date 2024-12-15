using Api.Persistencia.Interfaces;
using Infraestructura.Context;
using Infraestructura.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Persistencia.Repositories;

public class MarcaAutosRepository(AutosDbContext context) : IMarcaAutosRepository
{
    public async Task<IEnumerable<MarcaAutos>> GetAll()
    {
        return await context.MarcasAutos.ToListAsync();
    }


    public async Task<MarcaAutos?> GetById(int id)
    {
        return await context.MarcasAutos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }
}

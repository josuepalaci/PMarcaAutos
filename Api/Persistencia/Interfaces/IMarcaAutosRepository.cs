using Infraestructura.Models;

namespace Api.Persistencia.Interfaces;

public interface IMarcaAutosRepository
{
    Task<IEnumerable<MarcaAutos>> GetAll();
    Task<MarcaAutos?> GetById(int id);
}

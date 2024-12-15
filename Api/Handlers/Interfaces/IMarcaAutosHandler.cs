using Api.DTOs;

namespace Api.Handlers.Interfaces;

public interface IMarcaAutosHandler
{
    Task<IEnumerable<MarcaAutosResponse>> GetAll();
    Task<MarcaAutosResponse?> GetById(int id);
}

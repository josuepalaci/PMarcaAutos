using Api.DTOs;
using Api.Handlers.Interfaces;
using Api.Persistencia.Interfaces;

namespace Api.Handlers.MarcaAutos;

public class MarcaAutosHandler(IMarcaAutosRepository marcaAutosRepository) : IMarcaAutosHandler
{
    public async Task<IEnumerable<MarcaAutosResponse>> GetAll()
    {
        var list = await marcaAutosRepository.GetAll();

        // Mapping al DTO de respuesta para no exponer el modelo de dominio
        var resp = list
            .Select(x => new MarcaAutosResponse { Id = x.Id, Nombre = x.Nombre });

        return resp;
    }


    public async Task<MarcaAutosResponse?> GetById(int id)
    {
        var marca = await marcaAutosRepository.GetById(id);
        if ( marca == null )
            return null;

        // Mapping al DTO de respuesta para no exponer el modelo de dominio
        var resp = new MarcaAutosResponse { Id = marca.Id, Nombre = marca.Nombre };

        return resp;
    }
}

using Api.Handlers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasAutosController(IMarcaAutosHandler marcaAutosHandler) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var resp = await marcaAutosHandler.GetAll();
            return Ok(resp);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var resp = await marcaAutosHandler.GetById(id);
            if ( resp == null )
                return NotFound($"Marca de auto con id {id} no encontrada");

            return Ok(resp);
        }
    }
}

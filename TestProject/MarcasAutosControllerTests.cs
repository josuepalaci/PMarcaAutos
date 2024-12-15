using Moq;
using Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Api.DTOs;
using Api.Handlers.Interfaces;

namespace TestProject;

public class MarcasAutosControllerTests
{
    private readonly Mock<IMarcaAutosHandler> _mockHandler;
    private readonly MarcasAutosController _controller;


    public MarcasAutosControllerTests()
    {
        _mockHandler = new Mock<IMarcaAutosHandler>();
        _controller = new MarcasAutosController(_mockHandler.Object);
    }


    [Fact]
    public async Task Get_ReturnsOkWithListOfMarcas()
    {
        // Simula las marcas de autos
        var expectedDataList = new List<MarcaAutosResponse>
        {
            new() { Id = 1, Nombre = "Subaru" },
            new() { Id = 2, Nombre = "Toyota" },
            new() { Id = 3, Nombre = "Chevrolet" },
            new() { Id = 4, Nombre = "Ford" },
            new() { Id = 5, Nombre = "Nissan" },
            new() { Id = 6, Nombre = "Hyundai" }
        };
        _mockHandler.Setup(h => h.GetAll()).ReturnsAsync(expectedDataList);

        var result = await _controller.Get();

        var okResult = Assert.IsType<OkObjectResult>(result); // Verifica que sea un 200 OK
        Assert.Equal(expectedDataList, okResult.Value); // Verifica que el valor devuelto es el esperado
    }


    [Fact]
    public async Task GetById_ReturnsOkWithMarca()
    {
        var expectedModel = new MarcaAutosResponse() { Id = 2, Nombre = "Toyota" };

        _mockHandler.Setup(h => h.GetById(expectedModel.Id)).ReturnsAsync(expectedModel);

        var result = await _controller.Get(expectedModel.Id);

        var okResult = Assert.IsType<OkObjectResult>(result); // Verifica que sea un 200 OK
        Assert.Equal(expectedModel, okResult.Value); // Verifica que el valor devuelto es el esperado
    }


    [Fact]
    public async Task GetById_ReturnsNotFoundWhenMarcaDoesNotExist()
    {
        const int MarcaId = 99;
        _mockHandler.Setup(h => h.GetById(MarcaId))
            .ReturnsAsync((MarcaAutosResponse?)null); // Simula que no existe

        var result = await _controller.Get(MarcaId);

        var notFoundResult = Assert.IsType<NotFoundObjectResult>(result); // Verifica que sea un 404 NotFound
        Assert.Equal($"Marca de auto con id {MarcaId} no encontrada", notFoundResult.Value); // Verifica el mensaje
    }
}

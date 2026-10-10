using GenericCrud.API.DTOs;
using GenericCrud.API.Interfaces;
using GenericCrud.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace GenericCrud.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarrosController : ControllerBase
{
    private readonly ICarroService _carroService;

    public CarrosController(ICarroService carroService)
    {
        _carroService = carroService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Carro>>> Get()
    {
        var carros = await _carroService.ObterTodosAsync();
        return Ok(carros);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Carro>> GetById(int id)
    {
        var carro = await _carroService.ObterPorIdAsync(id);
        return carro is null ? NotFound() : Ok(carro);
    }

    [HttpPost]
    public async Task<ActionResult<Carro>> Post(CarroDto dto)
    {
        var novo = await _carroService.CriarAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = novo.Id }, novo);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Carro>> Put(int id, CarroDto dto)
    {
        var carro = await _carroService.AtualizarAsync(id, dto);
        return carro is null ? NotFound() : Ok(carro);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var removido = await _carroService.RemoverAsync(id);
        return removido ? NoContent() : NotFound();
    }
}
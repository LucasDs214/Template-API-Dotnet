using GenericCrud.API.DTOs;
using GenericCrud.API.Interfaces;
using GenericCrud.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace GenericCrud.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemController : ControllerBase
{
    private readonly IItemService _itemService;

    public ItemController(IItemService itemService)
    {
        _itemService = itemService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Item>>> Get()
    {
        var itens = await _itemService.ObterTodosAsync();
        return Ok(itens);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Item>> GetById(int id)
    {
        var item = await _itemService.ObterPorIdAsync(id);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<Item>> Post(ItemDto dto)
    {
        var novo = await _itemService.CriarAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = novo.Id }, novo);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Item>> Put(int id, ItemDto dto)
    {
        var item = await _itemService.AtualizarAsync(id, dto);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var removido = await _itemService.RemoverAsync(id);
        return removido ? NoContent() : NotFound();
    }
}
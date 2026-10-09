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

    [HttpPost]
    public async Task<ActionResult<Item>> Post(Item item)
    {
        var novoItem = await _itemService.CriarAsync(item);
        return Ok(novoItem);
    }
}
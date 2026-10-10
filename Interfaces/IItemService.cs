using GenericCrud.API.Models;
using GenericCrud.API.DTOs;

namespace GenericCrud.API.Interfaces;

public interface IItemService
{
    Task<IEnumerable<Item>> ObterTodosAsync();
    Task<Item?> ObterPorIdAsync(int id);
    Task<Item> CriarAsync(ItemDto dto);
    Task<Item?> AtualizarAsync(int id, ItemDto dto);
    Task<bool> RemoverAsync(int id);
}
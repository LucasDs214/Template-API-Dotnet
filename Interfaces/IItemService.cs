using GenericCrud.API.Models;

namespace GenericCrud.API.Interfaces;

public interface IItemService
{
    Task<IEnumerable<Item>> ObterTodosAsync();
    Task<Item> CriarAsync(Item item);
}
using GenericCrud.API.Interfaces;
using GenericCrud.API.Data;
using GenericCrud.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GenericCrud.API.Services;

public class ItemService : IItemService
{
    private readonly AppDbContext _context;

    public ItemService(AppDbContext _context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Item>> ObterTodosAsync()
    {
        return await _context.Itens.ToListAsync();
    }

    public async Task<Item> CriarAsync(Item item)
    {
        _context.Itens.Add(item);
        await _context.SaveChangesAsync();
        return item;
    }
}
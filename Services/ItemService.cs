using GenericCrud.API.Interfaces;
using GenericCrud.API.Data;
using GenericCrud.API.Models;
using GenericCrud.API.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GenericCrud.API.Services;

public class ItemService : IItemService
{
    private readonly AppDbContext _context;

    public ItemService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Item>> ObterTodosAsync()
    {
        return await _context.Itens.AsNoTracking().ToListAsync();
    }

    public async Task<Item?> ObterPorIdAsync(int id)
    {
        return await _context.Itens.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<Item> CriarAsync(ItemDto dto)
    {
        var item = new Item
        {
            Nome = dto.Nome,
            Descricao = dto.Descricao
        };

        _context.Itens.Add(item);
        await _context.SaveChangesAsync();
        return item;
    }

    public async Task<Item?> AtualizarAsync(int id, ItemDto dto)
    {
        var item = await _context.Itens.FindAsync(id);
        if (item is null) return null;

        item.Nome = dto.Nome;
        item.Descricao = dto.Descricao;
        await _context.SaveChangesAsync();
        return item;
    }

    public async Task<bool> RemoverAsync(int id)
    {
        var item = await _context.Itens.FindAsync(id);
        if (item is null) return false;

        _context.Itens.Remove(item);
        await _context.SaveChangesAsync();
        return true;
    }
}
using GenericCrud.API.Interfaces;
using GenericCrud.API.Data;
using GenericCrud.API.Models;
using GenericCrud.API.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GenericCrud.API.Services;

public class CarroService : ICarroService
{
    private readonly AppDbContext _context;

    public CarroService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Carro>> ObterTodosAsync()
    {
        return await _context.Carros.AsNoTracking().ToListAsync();
    }

    public async Task<Carro?> ObterPorIdAsync(int id)
    {
        return await _context.Carros.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<Carro> CriarAsync(CarroDto dto)
    {
        var carro = new Carro
        {
            Marca = dto.Marca,
            Modelo = dto.Modelo,
            Ano = dto.Ano,
            Preco = dto.Preco
        };

        _context.Carros.Add(carro);
        await _context.SaveChangesAsync();
        return carro;
    }

    public async Task<Carro?> AtualizarAsync(int id, CarroDto dto)
    {
        var carro = await _context.Carros.FindAsync(id);
        if (carro is null) return null;

        carro.Modelo = dto.Modelo;
        carro.Marca = dto.Marca;
        carro.Ano = dto.Ano;
        carro.Preco = dto.Preco;
        await _context.SaveChangesAsync();
        return carro;
    }

    public async Task<bool> RemoverAsync(int id)
    {
        var carro = await _context.Carros.FindAsync(id);
        if (carro is null) return false;

        _context.Carros.Remove(carro);
        await _context.SaveChangesAsync();
        return true;
    }
}
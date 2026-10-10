using GenericCrud.API.DTOs;
using GenericCrud.API.Models;

namespace GenericCrud.API.Interfaces;

public interface ICarroService
{
    Task<IEnumerable<Carro>> ObterTodosAsync();
    Task<Carro?> ObterPorIdAsync(int id);
    Task<Carro> CriarAsync(CarroDto dto);
    Task<Carro?> AtualizarAsync(int id, CarroDto dto);
    Task<bool> RemoverAsync(int id);
}
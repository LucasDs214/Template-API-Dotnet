namespace GenericCrud.API.Models;

public class Carro
{
    public int Id { get; set; }
    public string Marca { get; set; } = string.Empty;
    public string Modelo { get; set; } = string.Empty;
    public int Ano { get; set; }
    public decimal Preco { get; set; }
    public bool Vendido { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
}
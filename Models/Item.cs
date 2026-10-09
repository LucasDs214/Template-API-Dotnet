namespace GenericCrud.API.Models;

public class Item
{
    public int Id {get; set;}
    public string Nome {get; set;} = string.Empty;
    public string Descricao {get; set;} = string.Empty;
    public DateTime DataCriacao {get; set;} = DateTime.UtcNow;
}
using System.ComponentModel.DataAnnotations;

namespace GenericCrud.API.DTOs;

public class CarroDto
{
    [Required(ErrorMessage = "A marca é obrigatória")]
    public string Marca {get; set;} = string.Empty;

    [Required(ErrorMessage = "O modelo é obrigatório")]
    public string Modelo {get; set;} = string.Empty;

    [Range(1990, 2027, ErrorMessage = "o ano deve estar entre 1990 e 2027")]
    public int Ano {get;set;}

    [Range(0.01, 9999999, ErrorMessage = "O valor não pode ser vazio ou negativo")]
    public decimal Preco {get; set;}


}
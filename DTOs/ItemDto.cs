using System.ComponentModel.DataAnnotations;

namespace GenericCrud.API.DTOs;

public class ItemDto
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(100, MinimumLength = 2)]
    public string Nome {get; set;} = string.Empty;

    [StringLength(500)]
    public string Descricao {get; set;} = string.Empty;
}
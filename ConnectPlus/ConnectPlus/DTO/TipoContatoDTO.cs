using System.ComponentModel.DataAnnotations;

namespace ConnectPlus.DTO;

public class TipoContatoDTO
{
    [Required(ErrorMessage = "O tipo de contato é obrigatório")]
    public string? Titulo { get; set; }
}

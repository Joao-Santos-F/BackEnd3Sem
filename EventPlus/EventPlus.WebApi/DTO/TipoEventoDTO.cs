using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebApi.DTO;

public class TipoEventoDTO
{
    [Required(ErrorMessage = "O Título do evento é obrigatório")]
    public string? Titulo { get; set; }
}

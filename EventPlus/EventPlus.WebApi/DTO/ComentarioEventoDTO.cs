using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebApi.DTO;

public class ComentarioEventoDTO
{
    [Required(ErrorMessage = "A descrição do evento é obrigatória")]
    public string? Descricao { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebApi.DTO;

public class TipoUsuarioDTO
{
    [Required(ErrorMessage = "O nome de usuário  é obrigatório")]
    public string? Titulo { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebApi.DTO;

public class UsuarioDTO
{
    [Required(ErrorMessage = "O nome de usuário é obrigatório")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "O email de usuário é obrigatório")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "a senha do usuário é obrigatório")]
    public string? Senha { get; set; }
    public Guid? IdTipoUsuario { get; set; }
}

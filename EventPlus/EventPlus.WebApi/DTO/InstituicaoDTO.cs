using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebApi.DTO;

public class InstituicaoDTO
{
    [Required(ErrorMessage = "O endereço da instuição é obrigatória")]

    public string? CNPJ { get; set; }
}

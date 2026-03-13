using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebApi.DTO;

public class InstituicaoDTO
{
    [Required(ErrorMessage = "O CNPJ da instuição é obrigatória")]
    public string? Cnpj { get; set; }

    [Required(ErrorMessage = "O Endereço da instuição é obrigatória")]
    public string? Endereco { get; set; }

    [Required(ErrorMessage = "O Endereço da Nome Fantasia da instituição é obrigatória")]
    public string? NomeFantasia { get; set; }
}

using Azure.AI.ContentSafety;
using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebApi.DTO;

public class ComentarioEventoDTO
{
    public string? Descricao { get; set; }
    public Guid? IdUsuario { get; set; }
    public Guid? IdEvento { get; set;  }
}

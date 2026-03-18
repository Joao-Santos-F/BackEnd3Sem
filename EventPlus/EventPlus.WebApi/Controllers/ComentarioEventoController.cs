using EventPlus.WebApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ComentarioEventoController : ControllerBase
{
    private IComentarioEventoRepository _comentarioEventoRepository;

    public ComentarioEventoController(IComentarioEventoRepository comentarioEventoRepository) 
    {
        _comentarioEventoRepository = comentarioEventoRepository;
    }
}

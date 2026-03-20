using Azure;
using Azure.AI.ContentSafety;
using EventPlus.WebApi.DTO;
using EventPlus.WebApi.Interfaces;
using EventPlus.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ComentarioEventoController : ControllerBase
{
    private readonly ContentSafetyClient _contentSafetyClient;

    private readonly IComentarioEventoRepository _comentarioEventoRepository;

    public ComentarioEventoController(ContentSafetyClient contentSafetyClient, IComentarioEventoRepository comentarioEventoRepository)
    {
        _contentSafetyClient = contentSafetyClient;
        _comentarioEventoRepository = comentarioEventoRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Post(ComentarioEventoDTO comentarioEvento)
    {
        try
        {
            if (string.IsNullOrEmpty(comentarioEvento.Descricao))
            {
                return BadRequest("O texto a ser moderado não pode estar vazio");
            }

            //criar objeto de analise
            var request = new AnalyzeTextOptions(comentarioEvento.Descricao);

            //chamar a API do Azure content safety
            Response<AnalyzeTextResult> responde = await _contentSafetyClient.AnalyzeTextAsync(request);

            //verificar se o texto tem alguma severidade maior que 0
            bool temConteudoImproprio = responde.Value.CategoriesAnalysis.Any(c => c.Severity > 0);

            var novoComentario = new ComentarioEvento
            {
                IdEvento = comentarioEvento.IdEvento,
                IdUsuario = comentarioEvento.IdUsuario,
                Descricao = comentarioEvento.Descricao,
                Exibe = !temConteudoImproprio,
                DataComentarioEvento = DateTime.Now
            };

            _comentarioEventoRepository.Cadastrar(novoComentario);
            return StatusCode(201, novoComentario);

        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_comentarioEventoRepository.Listar());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("BuscarPorIdDeUsuario")]
    public IActionResult BuscarPorIdDeUsuario(Guid idUsuario)
    {
        try
        {
            return Ok(_comentarioEventoRepository.BuscarPorIdUsuario(idUsuario));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("ListarSomenteExibe")]
    public IActionResult ListarSomenteExibe(Guid IdEvento)
    {
        try
        {
            return Ok(_comentarioEventoRepository.ListarSomenteExibe(IdEvento));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Deletar(Guid id)
    {
        try
        {
            _comentarioEventoRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}

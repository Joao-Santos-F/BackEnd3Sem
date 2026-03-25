using ConnectPlus.DTO;
using ConnectPlus.Interface;
using ConnectPlus.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConnectPlus.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipoContatoController : ControllerBase
{
    private readonly ITipoContatoRepository _tipoContatoRepository;

    public TipoContatoController(ITipoContatoRepository tipoContatoRepository)
    {
        _tipoContatoRepository = tipoContatoRepository;
    }

    [HttpGet]
    public IActionResult Listar() 
    {
        try
        {
            return Ok(_tipoContatoRepository.Listar());
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    [HttpGet("{Id}")]
    public IActionResult BuscarPorId(Guid Id)
    {
        try
        {
            return Ok(_tipoContatoRepository.BuscarPorId(Id));
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public IActionResult Cadastrar(TipoContatoDTO tipoContato) 
    {
        try
        {
            var novoTipoContato = new TipoContato
            {
                Titulo = tipoContato.Titulo!
            };

            _tipoContatoRepository.Cadastrar(novoTipoContato);
            return StatusCode(201);

        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    [HttpPut("{Id}")]
    public IActionResult Atualizar(Guid Id, TipoContatoDTO tipoContato)
    {
        var tipoContatoBuscado = new TipoContato
        {
            Titulo = tipoContato.Titulo!
        };

        try
        {
            _tipoContatoRepository.Atualizar(Id, tipoContatoBuscado);
            return StatusCode(204, tipoContato);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{Id}")]
    public IActionResult Deletar(Guid Id)
    {
        try
        {
            _tipoContatoRepository.Deletar(Id);
            return NoContent();
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
    }

}

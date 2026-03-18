using EventPlus.WebApi.DTO;
using EventPlus.WebApi.Interfaces;
using EventPlus.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PresencaController : ControllerBase
{
    private IPresencaRepository _presencaRepository;

    public PresencaController(IPresencaRepository presencaRepository)
    {
        _presencaRepository = presencaRepository;
    }

    /// <summary>
    /// Metodo que lista as presencas de um usuario
    /// </summary>
    /// <param name="idUsuario">Id do usuario para filtragem</param>
    /// <returns>Status code 200 e uma lista de presenca</returns>
    [HttpGet("ListarMinhas/{idUsuario}")]
    public IActionResult ListarMinhas(Guid idUsuario) 
    {
        try
        {
            return Ok(_presencaRepository.ListarMinhas(idUsuario));
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }

    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_presencaRepository.Listar());
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_presencaRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Registra a presença de um usuário em um evento
    /// </summary>
    /// <param name="presenca"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Inscrever(PresencaDTO presenca)
    {

        try
        {
            var novaPresenca = new Presenca
            {
                Situacao = presenca.Situacao,
                IdEvento = presenca.IdEvento,
                IdUsuario = presenca.IdUsuario
            };

            _presencaRepository.Inscrever(novaPresenca);
            return StatusCode(201, novaPresenca);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

     [HttpPut("{id}")]
     public IActionResult Atualizar(Guid id, PresencaDTO presenca)
     {
         try
         {
            var presencaBuscada = new Presenca
            {
                Situacao = presenca.Situacao,
                IdEvento = presenca.IdEvento,
                IdUsuario = presenca.IdUsuario
            };

            _presencaRepository.Atualizar(id);
             return StatusCode(204, presencaBuscada);
         }
         catch (Exception erro)
         {
             return BadRequest(erro.Message);
         }
    }

    [HttpDelete("{id}")]
    public IActionResult Deletar(Guid id)
    {
        try
        {
            _presencaRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

}

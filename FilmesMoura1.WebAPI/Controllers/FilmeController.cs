using FilmesMoura1.WebAPI.Interfaces;
using FilmesMoura1.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace FilmesMoura1.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FilmeController : ControllerBase
{
    private readonly IFilmeRepository _filmeRepository;

    public FilmeController(IFilmeRepository filmeRepository)
    {

        _filmeRepository = filmeRepository;
    }

    [HttpPost]

    // Posta o flme
    public IActionResult Post(Filme novoFilme)
    {
        try
        {
            _filmeRepository.Cadastrar(novoFilme);
            return StatusCode(201);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]

    //Busca o filme pelo id
    public IActionResult GetById(Guid id)
    {
        try
        {
            return Ok(_filmeRepository.BuscarPorId(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]

    // Busca todos os filmes
    public IActionResult Get()
    {
        try
        {
            return Ok(_filmeRepository.Listar());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]

    // Atualiza o filme pelo id
    public IActionResult Put(Guid id, Filme filmeAtualizado)
    {
        try
        {
            _filmeRepository.AtualizarIdUrl(id, filmeAtualizado);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]

    // Atualiza o filme pelo corpo da requisição
    public IActionResult Put(Filme filmeAtualizado)
    {
        try
        {
            _filmeRepository.AtualizarIdCorpo(filmeAtualizado);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]

    // Deleta o filme pelo id
    public IActionResult Delete(Guid id)
    {
        try
        {
            _filmeRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}

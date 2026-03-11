using EventPlus.WebApi.DTO;
using EventPlus.WebApi.Interfaces;
using EventPlus.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InstituicaoController : ControllerBase
{
    private IInstituicaoRepository _instituicaoRepository;

    public InstituicaoController(IInstituicaoRepository instituicaoRepository)
    {
        _instituicaoRepository = instituicaoRepository;
    }

    /// <summary>
    /// Endpoint da API que faz a chamada para o método de listar as instituições
    /// </summary>
    /// <returns>Status code 2oo e a lista de instituicaos</returns>
    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_instituicaoRepository.Listar());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz a chamada para o método de buscar uma instituição por id
    /// </summary>
    /// <param name="id">Id da instituicao buscada</param>
    /// <returns>Status code 200 e a instituicao buscada</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_instituicaoRepository.BuscarPorId(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz a chamada para o método de cadastrar uma nova instituição
    /// </summary>
    /// <param name="instituicao">A instituicao que deve ser cadastrada</param>
    /// <returns>Status code 201 e a instituicao a ser cadastrada</returns>
    [HttpPost]
    public IActionResult Cadastrar(InstituicaoDTO instituicao)
    {
        var novaInstituicao = new Instituicao { 
            Cnpj = instituicao.CNPJ!

        };

        try
        {
            _instituicaoRepository.Cadastrar(novaInstituicao);
            return StatusCode(201);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz a chamada para o nétodo de atualizar uma instituicao
    /// </summary>
    /// <param name="id">Id da instituicao a ser atualizada</param>
    /// <param name="instituicao">Instituicao com os dados atualizados</param>
    /// <returns>Status code 204 e a instituicao atualizada</returns>
    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, InstituicaoDTO instituicao)
    {
        var instituicaoAtualizada = new Instituicao { 
            Cnpj = instituicao.CNPJ!

        };

        try
        {
            _instituicaoRepository.Atualizar(id, instituicaoAtualizada);
            return StatusCode(204);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz a chamada para o método de deletar uma instituição
    /// </summary>
    /// <param name="id">Id da instituicao a ser excluida</param>
    /// <returns>Status code 204</returns>
    [HttpDelete("{id}")]
    public IActionResult Deletar(Guid id)
    {
        try
        {
            _instituicaoRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}

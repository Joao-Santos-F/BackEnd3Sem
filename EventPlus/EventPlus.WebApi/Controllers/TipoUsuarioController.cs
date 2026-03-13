using EventPlus.WebApi.DTO;
using EventPlus.WebApi.Interfaces;
using EventPlus.WebApi.Models;
using EventPlus.WebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipoUsuarioController : ControllerBase
{
    private ITipoUsuarioRepository _tipoUsuarioRepository;

    public TipoUsuarioController(ITipoUsuarioRepository tipoUsuarioRepository)
    {
        _tipoUsuarioRepository = tipoUsuarioRepository;
    }

    /// <summary>
    /// Endpoint da API que faz a chamada para o método de listar os tipos de usuários
    /// </summary>
    /// <returns>Status code 200 e a lisra de tipos usuários </returns>
    [HttpGet]
    public IActionResult Listar() 
    {
        try
        {
            return Ok(_tipoUsuarioRepository.Listar());
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz a chamada para o método de buscar um tipo de usuário por id
    /// </summary>
    /// <param name="Id">Id do tipo usuário buscado</param>
    /// <returns>Status code 200 e o tipo de usuário buscado</returns>
    [HttpGet("{Id}")]
    public IActionResult BuscarPorId(Guid Id)
    {
        try
        {
            return Ok(_tipoUsuarioRepository.BuscarPorId(Id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz a chamada para o método de cadastrar um tipo de usuário
    /// </summary>
    /// <param name="tipoUsuario">Tipo de usuário a ser cadastrado</param>
    /// <returns>Status code 201 e o tipo usuário a ser cadastrado</returns>
    [HttpPost]
    public IActionResult Cadastrar(TipoUsuarioDTO tipoUsuario)
    {
        try
        {
            var novoTipoUsuario = new TipoUsuario
            {
                Titulo = tipoUsuario.Titulo!
            };

            _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);
            return StatusCode(201);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// EndPoint da API que faz a chamada para o método de atualizar um tipo de usuário
    /// </summary>
    /// <param name="Id">Id do tipo de usuário a ser atualizado</param>
    /// <param name="tipoUsuario">Tipo de usuário com os tipos atualizados</param>
    /// <returns>Status code 204 e  o tipo de usuário atualizado</returns>
    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid Id, TipoUsuarioDTO tipoUsuario)
    {
        var  tipoUsuarioAtualizado = new TipoUsuario
        {
            Titulo = tipoUsuario.Titulo!
        };

        try
        {
            _tipoUsuarioRepository.Atualizar(Id, tipoUsuarioAtualizado);
            return StatusCode(204, tipoUsuario);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz a chamada para o método de deletar um tipo de usuário
    /// </summary>
    /// <param name="Id">Id do tipo de usuário a sr excluido</param>
    /// <returns>Status code 204</returns>
    [HttpDelete("{id}")]
    public IActionResult Deletar(Guid Id)
    {
        try
        {
            _tipoUsuarioRepository.Deletar(Id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}

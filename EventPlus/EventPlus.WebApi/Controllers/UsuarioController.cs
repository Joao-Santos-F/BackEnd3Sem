using EventPlus.WebApi.DTO;
using EventPlus.WebApi.Interfaces;
using EventPlus.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    /// <summary>
    /// Endpoint da API que faz a chamada para o método de buscar um usuário por email e senha
    /// </summary>
    /// <param name="id">ID so usuario a ser buscado</param>
    /// <returns>Status code 200 e o usuario a ser buscado</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_usuarioRepository.BurcarPorId(id));
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }


    /// <summary>
    /// Endpoint da API que faz a chamada para o método de cadastrar um novo usuário
    /// </summary>
    /// <param name="usuario">Usuario a ser cadastrado</param>
    /// <returns>Status 201 e o usuário cadastrado</returns>
    [HttpPost]
    public IActionResult Cadastrar(UsuarioDTO usuario)
    {
        var novoUsuario = new Usuario
        {
            Nome = usuario.Nome!,
            Email = usuario.Email!,
            Senha = usuario.Senha!,
            IdTipoUsuario = usuario.IdTipoUsuario
        };

        try
        {
            _usuarioRepository.Cadastrar(novoUsuario);
            return StatusCode(201);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

}

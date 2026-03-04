using FilmesMoura1.WebAPI.Interfaces;
using FilmesMoura1.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmesMoura1.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioRepository _usuarioRepostiroy;

    public UsuarioController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepostiroy = usuarioRepository;
    }

    [HttpPost]
    //Cadastra um novo usuário
    public IActionResult Post(Usuario novoUsuario)
    {
        try
        {
            _usuarioRepostiroy.Cadastrar(novoUsuario);
            return StatusCode(201);
        }
        catch (Exception erro)
        {

            return BadRequest(erro.Message);
        }
    }

}

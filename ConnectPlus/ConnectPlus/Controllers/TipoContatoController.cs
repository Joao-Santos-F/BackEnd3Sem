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

    /// <summary>
    /// EndPoint da API que lista os Tipos de Contatos existentes
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// EndPoint da API que Busca um tipo de contato pelo id 
    /// </summary>
    /// <param name="Id">ID do tipo de contato a ser buscado</param>
    /// <returns>O tipo de contato com o id exato já existente</returns>
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

    /// <summary>
    /// EndPoint da API que cadastra um novo tipo de contato
    /// </summary>
    /// <param name="tipoContato">Informacoes a serem aducionadas para cadastrar um contato</param>
    /// <returns>Tipo de contato cadastrado e Status code 201s</returns>
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

    /// <summary>
    /// EndPoint da API que atualiza um tipo de contato já existente
    /// </summary>
    /// <param name="Id">ID do tipo de contato a ser atualizado</param>
    /// <param name="tipoContato">Informacoes do tipo de contato a ser atualizado</param>
    /// <returns>Tipo de contato atualizado e Status Code 204</returns>
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

    /// <summary>
    /// EndPoint da API que deleta um tipo de contato que já existe
    /// </summary>
    /// <param name="Id">ID do tipo de contato a ser deletado</param>
    /// <returns>Tipo de contato deletado e NoContent</returns>
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

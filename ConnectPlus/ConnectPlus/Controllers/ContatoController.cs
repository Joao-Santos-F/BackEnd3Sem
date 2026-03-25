using ConnectPlus.DTO;
using ConnectPlus.Interface;
using ConnectPlus.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConnectPlus.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContatoController : ControllerBase
{
    private readonly IContatoRepository _contatoRepository;

    public ContatoController(IContatoRepository contatoRepository)
    {
        _contatoRepository = contatoRepository;
    }

    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_contatoRepository.Listar());
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
            return Ok(_contatoRepository.BuscarPorId(Id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar([FromForm] ContatoDTO contato)
    {
        try
        {
            var novoContato = new Contato
            {
                Nome = contato.Nome!,
                FormaContato = contato.FormaContato!,
                IdTipoContato = contato.IdTipoContato
            };

            // Lógica de salvar imagem extraída do seu exemplo
            if (contato.Imagem != null && contato.Imagem.Length > 0)
            {
                var extensao = Path.GetExtension(contato.Imagem.FileName);
                var nomeArquivo = $"{Guid.NewGuid()}{extensao}";
                var pastaRelativa = "wwwroot/imagens";
                var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), pastaRelativa);

                if (!Directory.Exists(caminhoPasta))
                    Directory.CreateDirectory(caminhoPasta);

                var caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);

                using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                {
                    await contato.Imagem.CopyToAsync(stream);
                }

                novoContato.Imagem = nomeArquivo;
            }

            _contatoRepository.Cadastrar(novoContato);
            return StatusCode(201);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> Atualizar(Guid Id, [FromForm] ContatoDTO contato)
    {
        try
        {
            var contatoBuscado = new Contato
            {
                Nome = contato.Nome!,
                FormaContato = contato.FormaContato!,
                IdTipoContato = contato.IdTipoContato
            };

            // Lógica de salvar imagem no Atualizar
            if (contato.Imagem != null && contato.Imagem.Length > 0)
            {
                var extensao = Path.GetExtension(contato.Imagem.FileName);
                var nomeArquivo = $"{Guid.NewGuid()}{extensao}";
                var pastaRelativa = "wwwroot/imagens";
                var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), pastaRelativa);

                if (!Directory.Exists(caminhoPasta))
                    Directory.CreateDirectory(caminhoPasta);

                var caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);

                using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                {
                    await contato.Imagem.CopyToAsync(stream);
                }

                contatoBuscado.Imagem = nomeArquivo;
            }

            _contatoRepository.Atualizar(Id, contatoBuscado);
            return StatusCode(204, contatoBuscado);
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
            _contatoRepository.Deletar(Id);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
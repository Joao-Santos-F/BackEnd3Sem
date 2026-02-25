using FilmesMoura1.WebAPI.BdContextFilme;
using FilmesMoura1.WebAPI.Interfaces;
using FilmesMoura1.WebAPI.Models;

namespace FilmesMoura1.WebAPI.Repositories;

public class FilmeRepository : IFilmeRepository
{

    private readonly FilmeContext _context;

    public FilmeRepository(FilmeContext context)
    {
        _context = context;
    }

    public void AtualizarIdCorpo(Filme filmeAtualizado)
    {
        try
        {
            Filme filmeBuscado = _context.Filmes.Find(filmeAtualizado.IdFilme);

            if (filmeBuscado != null)
            {
                filmeBuscado.Titulo = filmeAtualizado.Titulo;
            }

            _context.Filmes.Update(filmeBuscado);
            _context.SaveChanges();

        }
        catch (Exception)
        {

            throw;
        }
    }

    public void AtualizarIdUrl(Guid Id, Filme filmeAtualizado)
    {
        try
        {
            Filme filmeBuscado = _context.Filmes.Find(Id.ToString())!;
            if (filmeBuscado != null)
            {
                filmeBuscado.Titulo = filmeAtualizado.Titulo;

                _context.Filmes.Update(filmeBuscado);
                _context.SaveChanges();
            }
        }
        catch (Exception)
        {

            throw;
        }
    }

    public Filme BuscarPorId(Guid Id)
    {
        try
        {
            Filme filmeBucado = _context.Filmes.Find(Id.ToString())!;
            return filmeBucado;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Cadastrar(Filme novoFilme)
    {
        try
        {
            novoFilme.IdFilme = Guid.NewGuid().ToString();

            _context.Filmes.Add(novoFilme);
            _context.SaveChanges();
        }
        catch (Exception)
        {

            throw;
        }
    }

    public void Deletar(Guid Id)
    {
        try
        {
            Filme filmeBuscado = _context.Filmes.Find(Id.ToString())!;

            if (filmeBuscado != null)
            {
                _context.Filmes.Remove(filmeBuscado);
            }
                _context.SaveChanges();
        }
        catch (Exception)
        {

            throw;
        }
    }

    public List<Filme> Listar()
    {
        try
        {
            List<Filme> ListaFilmes = _context.Filmes.ToList();

            return ListaFilmes;

        }
        catch (Exception)
        {

            throw;
        }
    }
}

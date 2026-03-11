using EventPlus.WebApi.BdContextEvent;
using EventPlus.WebApi.Interfaces;
using EventPlus.WebApi.Models;

namespace EventPlus.WebApi.Repositories;

public class TipoUsuarioRepository : ITipoUsuarioRepository
{
    private readonly EventContext _context;

    public TipoUsuarioRepository(EventContext context)
    {
        _context = context;
    }

    public void Atualizar(Guid id, TipoUsuario tipoUsuario)
    {
        var TipoUsuarioBuscado = _context.TipoUsuarios.Find(id);

        if (TipoUsuarioBuscado != null)
        {
            TipoUsuarioBuscado.Titulo = tipoUsuario.Titulo;
            _context.SaveChanges();
        }
    }

    public TipoUsuario BuscarPorId(Guid Id)
    {
        return _context.TipoUsuarios.Find(Id)!;
    }

    public void Cadastrar(TipoUsuario tipoUsuario)
    {
        _context.TipoUsuarios.Add(tipoUsuario);
        _context.SaveChanges();
    }

    public void Deletar(Guid Id)
    {
        var tipoUsuarioBuscado = _context.TipoUsuarios.Find(Id);

        if (tipoUsuarioBuscado != null)
        {
            _context.TipoUsuarios.Remove(tipoUsuarioBuscado);
            _context.SaveChanges();
        }
    }

    public List<TipoUsuario> Listar()
    {
        return _context.TipoUsuarios.OrderBy(TipoUsuario => TipoUsuario.Titulo).ToList();
    }
}

using ConnectPlus.BdContextConnect;
using ConnectPlus.Interface;
using ConnectPlus.Models;

namespace ConnectPlus.Repository;

public class TipoContatoRepository : ITipoContatoRepository
{
    private readonly ConnectContext _context;

    public TipoContatoRepository(ConnectContext context)
    {
        _context = context;
    }

    public void Atualizar(Guid Id, TipoContato tipoContato)
    {
        var tipoContatoBuscado = _context.TipoContatos.Find(Id);

        if (tipoContatoBuscado != null)
        {
            tipoContatoBuscado.Titulo = tipoContato.Titulo;
            _context.SaveChanges();
        }
    }

    public TipoContato BuscarPorId(Guid Id)
    {
        return _context.TipoContatos.Find(Id)!;
    }

    public void Cadastrar(TipoContato tipoContato)
    {
        _context.TipoContatos.Add(tipoContato);
        _context.SaveChanges();
    }

    public void Deletar(Guid Id)
    {
        var tipoContatoBuscado = _context.TipoContatos.Find(Id);

        if (tipoContatoBuscado != null)
        {
            _context.TipoContatos.Remove(tipoContatoBuscado);
            _context.SaveChanges();
        }
    }

    public List<TipoContato> Listar()
    {
        return _context.TipoContatos.OrderBy(tipoContato => tipoContato.Titulo).ToList();
    }
}

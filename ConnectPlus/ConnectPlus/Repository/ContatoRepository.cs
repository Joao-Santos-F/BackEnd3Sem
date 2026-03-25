using ConnectPlus.BdContextConnect;
using ConnectPlus.Interface;
using ConnectPlus.Models;

namespace ConnectPlus.Repository;

public class ContatoRepository : IContatoRepository
{
    private readonly ConnectContext _context;

    public ContatoRepository(ConnectContext context) 
    {
        _context = context;
    }

    public void Atualizar(Guid Id, Contato contato)
    {
        var contatoBuscado = _context.Contatos.Find(Id);

        if (contatoBuscado != null)
        {
            contatoBuscado.Nome = contato.Nome;
            contatoBuscado.Imagem = contato.Imagem;
            contatoBuscado.FormaContato = contato.FormaContato;
            contatoBuscado.IdTipoContato = contato.IdTipoContato;
            _context.SaveChanges();
        }
    }

    public Contato BuscarPorId(Guid Id)
    {
        return _context.Contatos.Find(Id)!;
    }

    public void Cadastrar(Contato contato)
    {
        _context.Contatos.Add(contato);
        _context.SaveChanges();
    }

    public void Deletar(Guid Id)
    {
        var contatoBuscado = _context.Contatos.Find(Id);

        if (contatoBuscado != null)
        {
            _context.Contatos.Remove(contatoBuscado);
            _context.SaveChanges();
        }
    }

    public List<Contato> Listar()
    {
        return _context.Contatos.OrderBy(c => c.Nome).ToList();
    }
}

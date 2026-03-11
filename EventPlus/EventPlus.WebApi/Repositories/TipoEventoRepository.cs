using EventPlus.WebApi.BdContextEvent;
using EventPlus.WebApi.Interfaces;
using EventPlus.WebApi.Models;

namespace EventPlus.WebApi.Repositories;

public class TipoEventoRepository : ITipoEventoRepository
{
    private readonly EventContext _context;
    //injecao de dependencia : Recebe contexto pelo construtor
    public TipoEventoRepository(EventContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Atualiza um tipo de evento usando o rastreamento automatico
    /// </summary>
    /// <param name="Id">id do tipo evento a ser atualizado</param>
    /// <param name="tipoEvento">Novos dados do tipo evento</param>
    public void Atualizar(Guid Id, TipoEvento tipoEvento)
    {
        var TipoEventoBuscado = _context.TipoEventos.Find(Id);

        if (TipoEventoBuscado != null)
        {
            TipoEventoBuscado.Titulo = tipoEvento.Titulo;

            //O savechanges detecta a mudanca na propriedade titulo automaticamente
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Busca um tipo de evento por id
    /// </summary>
    /// <param name="Id">id do tipo evento a ser buscado</param>
    /// <returns>objeto do tipo evento com as informacoes do tipo de evento buscado</returns>
    public TipoEvento BuscarPorId(Guid Id)
    {
        return _context.TipoEventos.Find(Id)!;
    }

    /// <summary>
    /// Cadastra um novo tipo de eventi
    /// </summary>
    /// <param name="tipoEvento">Tipo de evento a ser cadastrado</param>
    public void Cadastrar(TipoEvento tipoEvento)
    {
        _context.TipoEventos.Add(tipoEvento);
        _context.SaveChanges();
    }

    /// <summary>
    /// Deleta um tipo de evento
    /// </summary>
    /// <param name="Id">id do tipo evento a ser deletado</param>
    public void Deletar(Guid Id)
    {
        var tipoEventoBuscado = _context.TipoEventos.Find(Id);

        if (tipoEventoBuscado != null)
        {
            _context.TipoEventos.Remove(tipoEventoBuscado);
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// busca o tipo de eventos cadastrados
    /// </summary>
    /// <returns>Uma lista do tipo eventos</returns>
    public List<TipoEvento> Listar()
    {
        return _context.TipoEventos.OrderBy(tipoEvento => tipoEvento.Titulo).ToList();
    }

}

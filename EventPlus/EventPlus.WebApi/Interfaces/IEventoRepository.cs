using EventPlus.WebApi.Models;

namespace EventPlus.WebApi.Interfaces;

public interface IEventoRepository
{
    void Cadastrar(Evento evento);
    List<Evento> Listar();
    void Deletar(Guid Id);
    void Atualizar(Guid Id, Evento evento);
    Evento BuscarPorId(Guid Id);
    List<Evento> ListarPorId(Guid IdUsuario);
    List<Evento> ListarProximos();
}

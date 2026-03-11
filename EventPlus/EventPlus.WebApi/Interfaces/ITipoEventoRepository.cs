using EventPlus.WebApi.Models;

namespace EventPlus.WebApi.Interfaces;

public interface ITipoEventoRepository
{
    void Cadastrar(TipoEvento tipoEvento);
    TipoEvento BuscarPorId(Guid Id);
    void Deletar(Guid Id);
    List<TipoEvento> Listar();
    void Atualizar(Guid Id, TipoEvento tipoEvento);
}

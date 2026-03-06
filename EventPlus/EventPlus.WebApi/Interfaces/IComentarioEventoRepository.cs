using EventPlus.WebApi.Models;

namespace EventPlus.WebApi.Interfaces;

public interface IComentarioEventoRepository
{
    void Cadastrar(ComentarioEvento comentarioEvento);

    void Deletar(Guid idComentarioEvento);

    List<ComentarioEvento> Listar(Guid IdEvento);
    ComentarioEvento BuscarPorIdUsuario(Guid idUsuario, Guid Idevento);
    List<ComentarioEvento> ListarSomenteExibe(Guid IdEvento);
}

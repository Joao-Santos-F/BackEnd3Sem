using EventPlus.WebApi.Models;

namespace EventPlus.WebApi.Interfaces;

public interface IPresencaRepository
{
    void Inscrever(Presenca presenca);
    void Deletar(Guid Id);
    List<Presenca> Listar(Guid Id);
    Presenca BuscarPorId(Guid Id);
    void Atualizar(Guid Id, Presenca presenca);
    List<Presenca> ListarMinhas(Guid IdUsuario);
}

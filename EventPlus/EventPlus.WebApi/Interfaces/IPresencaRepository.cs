using EventPlus.WebApi.Models;

namespace EventPlus.WebApi.Interfaces;

public interface IPresencaRepository
{
    void Inscrever(Presenca presenca);
    void Deletar(Guid Id);
    List<Presenca> Listar();
    Presenca BuscarPorId(Guid Id);
    void Atualizar(Guid Id);
    List<Presenca> ListarMinhas(Guid IdUsuario);
}

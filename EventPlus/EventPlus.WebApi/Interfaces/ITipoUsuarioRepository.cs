using EventPlus.WebApi.Models;

namespace EventPlus.WebApi.Interfaces;

public interface ITipoUsuarioRepository
{
    void Cadastrar(TipoUsuario tipoUsuario);
    TipoUsuario BuscarPorId(Guid Id);
    List<TipoUsuario> Listar();
    void Deletar(Guid Id);
    void Atualizar(Guid id, TipoUsuario tipoUsuario);
}

using EventPlus.WebApi.Models;

namespace EventPlus.WebApi.Interfaces;

public interface IUsuarioRepository
{
    void Cadastrar(Usuario usuario);
    Usuario BurcarPorId(Guid IdUsuario);
    Usuario BuscarPorEmailESenha(string Email, string Senha);
}

using EventPlus.WebApi.BdContextEvent;
using EventPlus.WebApi.Interfaces;
using EventPlus.WebApi.Models;
using EventPlus.WebApi.Utils;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebApi.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly EventContext _context;

    public UsuarioRepository(EventContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Busca um usuário por email e valida o hash da senha
    /// </summary>
    /// <param name="Email">Email do usuario</param>
    /// <param name="Senha">Senha do usuario</param>
    /// <returns>Usuario buscado e validado</returns>
    public Usuario BuscarPorEmailESenha(string Email, string Senha)
    {
        // primeiro, buscamos o usuário pelo email
        var usuarioBuscado = _context.Usuarios.Include(usuario => usuario.IdTipoUsuarioNavigation).FirstOrDefault(usuario => usuario.Email == Email);

        //verifica se o usuario realmente existe
        if (usuarioBuscado != null)
        {
            //comparamos o hash da senha digitada com a senha que esta no banco
            bool confere = Criptografia.CompararHash(Senha, usuarioBuscado.Senha);

            if (confere)
            {
                return usuarioBuscado;
            }
        }
        return null!;
    }

    /// <summary>
    /// Busca um usuário por seu ID, incluindo os dados do seu tipo usuário.
    /// </summary>
    /// <param name="IdUsuario">Id do usuario a ser buscado</param>
    /// <returns>Retorna o usuario buscado</returns>
    public Usuario BurcarPorId(Guid IdUsuario)
    {
        return _context.Usuarios
            .Include(usuario => usuario.IdTipoUsuarioNavigation)
            .FirstOrDefault(usuario => usuario.IdUsuario == IdUsuario)!;
    }

    /// <summary>
    /// Cadastra um novo usuario com a senha criptografada
    /// </summary>
    /// <param name="usuario">Usuario a ser cadastrado</param>
    public void Cadastrar(Usuario usuario)
    {
        usuario.Senha = Criptografia.GerarHash(usuario.Senha);

        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
    }

    public List<Usuario> Listar()
    {
        return _context.Usuarios.OrderBy(usuario => usuario.IdUsuario).ToList();
    }
}

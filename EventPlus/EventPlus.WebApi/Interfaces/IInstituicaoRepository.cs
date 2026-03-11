using EventPlus.WebApi.Models;

namespace EventPlus.WebApi.Interfaces;

public interface IInstituicaoRepository
{
    void Cadastrar(Instituicao instituicao);
    Instituicao BuscarPorId(Guid Id);
    void Deletar(Guid Id);
    List<Instituicao> Listar();
    void Atualizar(Guid Id, Instituicao instituicao);
}

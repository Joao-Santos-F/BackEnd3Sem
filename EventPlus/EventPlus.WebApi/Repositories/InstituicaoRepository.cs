using EventPlus.WebApi.BdContextEvent;
using EventPlus.WebApi.Interfaces;
using EventPlus.WebApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EventPlus.WebApi.Repositories;

public class InstituicaoRepository : IInstituicaoRepository
{
    private readonly EventContext _context;

    public InstituicaoRepository(EventContext context)
    {
        _context = context;
    }

    public void Atualizar(Guid Id, Instituicao instituicao)
    {
        var InstituicaoBuscada = _context.Instituicaos.Find();

        if (InstituicaoBuscada != null)
        {
            InstituicaoBuscada.Cnpj = instituicao.Cnpj;
            InstituicaoBuscada.Endereco = instituicao.Endereco;
            InstituicaoBuscada.NomeFantasia = instituicao.NomeFantasia;
            _context.SaveChanges();
        }
    }

    public Instituicao BuscarPorId(Guid Id)
    {
        return _context.Instituicaos.Find(Id)!;
    }

    public void Cadastrar(Instituicao instituicao)
    {
        _context.Instituicaos.Add(instituicao);
        _context.SaveChanges();
    }

    public void Deletar(Guid Id)
    {
        var instituicaoBuscada = _context.Instituicaos.Find(Id);

        if (instituicaoBuscada != null)
        {
            _context.Instituicaos.Remove(instituicaoBuscada);
            _context.SaveChanges();
        }
    }

    public List<Instituicao> Listar()
    {
        return _context.Instituicaos.OrderBy(Instituicao => Instituicao.NomeFantasia).ToList();
    }
}

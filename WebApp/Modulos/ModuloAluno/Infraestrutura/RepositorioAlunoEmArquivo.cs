using EscolaDeCursos.WebApp.Compartilhado.Infraestrutura.Arquivos;
using EscolaDeCursos.WebApp.Modulos.ModuloAluno.Dominio;

namespace EscolaDeCursos.WebApp.Modulos.ModuloAluno.Infraestrutura;

public sealed class RepositorioAlunoEmArquivo(ContextoJson contexto)
    : RepositorioBaseEmArquivo<Aluno>(contexto), IRepositorioAluno
{
    public bool ExisteComCpf(string cpf, Guid? idIgnorado = null)
    {
        string cpfSemMascara = RemoverMascaraCpf(cpf);

        return registros.Any(a =>
            a.Id != idIgnorado &&
            RemoverMascaraCpf(a.Cpf) == cpfSemMascara
        );
    }

    private static string RemoverMascaraCpf(string cpf)
    {
        return cpf.Replace(".", "").Replace("-", "").Trim();
    }

    protected override List<Aluno> ObterRegistros(ContextoJson contexto)
    {
        return contexto.Alunos;
    }
}

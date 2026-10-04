using EscolaDeCursos.WebApp.Compartilhado.Infraestrutura.Orm;
using EscolaDeCursos.WebApp.Modulos.ModuloAluno.Dominio;

namespace EscolaDeCursos.WebApp.Modulos.ModuloAluno.Infraestrutura;

public sealed class RepositorioAlunoEmOrm(EscolaDeCursosDbContext dbContext) : IRepositorioAluno
{
    public void Cadastrar(Aluno entidade)
    {
        dbContext.Alunos.Add(entidade); // Adiciona em memória

        dbContext.SaveChanges(); // Salva em banco
    }

    public bool Editar(Guid idSelecionado, Aluno entidadeAtualizada)
    {
        Aluno? alunoSelecionado = SelecionarPorId(idSelecionado);

        if (alunoSelecionado == null)
            return false;

        alunoSelecionado.Atualizar(entidadeAtualizada);

        dbContext.SaveChanges();

        return true;
    }

    public bool Excluir(Guid idSelecionado)
    {
        Aluno? alunoSelecionado = SelecionarPorId(idSelecionado);

        if (alunoSelecionado == null)
            return false;

        dbContext.Alunos.Remove(alunoSelecionado);

        dbContext.SaveChanges();

        return true;
    }

    public Aluno? SelecionarPorId(Guid idSelecionado)
    {
        return dbContext.Alunos.SingleOrDefault(a => a.Id == idSelecionado);
    }

    public List<Aluno> SelecionarTodos()
    {
        return dbContext.Alunos.ToList();
    }

    public bool ExisteComCpf(string cpf, Guid? idIgnorado = null)
    {
        // Compara apenas os dígitos: "123.456.789-01" e "12345678901" são o mesmo CPF
        string cpfSemMascara = cpf.Replace(".", "").Replace("-", "").Trim();

        return dbContext.Alunos.Any(a =>
            a.Id != idIgnorado &&
            a.Cpf.Replace(".", "").Replace("-", "").Trim() == cpfSemMascara
        );
    }
}

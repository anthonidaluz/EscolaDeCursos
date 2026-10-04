using EscolaDeCursos.WebApp.Compartilhado.Dominio;

namespace EscolaDeCursos.WebApp.Modulos.ModuloAluno.Dominio;

public interface IRepositorioAluno : IRepositorio<Aluno>
{
    bool ExisteComCpf(string cpf, Guid? idIgnorado = null);
}

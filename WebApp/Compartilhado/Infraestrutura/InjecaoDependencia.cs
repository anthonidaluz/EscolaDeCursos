using EscolaDeCursos.WebApp.Modulos.ModuloAluno.Dominio;
using EscolaDeCursos.WebApp.Modulos.ModuloInstrutor.Dominio;
using EscolaDeCursos.WebApp.Compartilhado.Infraestrutura.Arquivos;
using EscolaDeCursos.WebApp.Modulos.ModuloAluno.Infraestrutura;
using EscolaDeCursos.WebApp.Modulos.ModuloInstrutor.Infraestrutura;
using EscolaDeCursos.WebApp.Modulos.ModuloCurso.Dominio;
using EscolaDeCursos.WebApp.Modulos.ModuloCurso.Infraestrutura;

namespace EscolaDeCursos.WebApp.Compartilhado.Infraestrutura;

public static class InjecaoDependencia
{
    public static void AddInfraRepositories(this IServiceCollection services)
    {
        services.AddSingleton<ContextoJson>(_ =>
        {
            ContextoJson contexto = new();
            contexto.Carregar();
            return contexto;
        });

        services.AddScoped<IRepositorioInstrutor, RepositorioInstrutorEmArquivo>();
        services.AddScoped<IRepositorioAluno, RepositorioAlunoEmArquivo>();
        services.AddScoped<IRepositorioCurso, RepositorioCursoEmArquivo>();
        services.AddScoped<IRepositorioAula, RepositorioAulaEmArquivo>();
    }
}

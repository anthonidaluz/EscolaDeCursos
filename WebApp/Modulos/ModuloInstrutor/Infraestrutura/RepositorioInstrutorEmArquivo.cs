using EscolaDeCursos.WebApp.Compartilhado.Infraestrutura.Arquivos;
using EscolaDeCursos.WebApp.Modulos.ModuloInstrutor.Dominio;

namespace EscolaDeCursos.WebApp.Modulos.ModuloInstrutor.Infraestrutura;

public sealed class RepositorioInstrutorEmArquivo(ContextoJson contexto)
    : RepositorioBaseEmArquivo<Instrutor>(contexto), IRepositorioInstrutor
{
    public bool ExisteComNome(string nome, Guid? idIgnorado = null)
    {
        return registros.Any(i =>
            i.Id != idIgnorado &&
            string.Equals(i.Nome.Trim(), nome.Trim(), StringComparison.OrdinalIgnoreCase)
        );
    }

    public bool ExisteComTelefone(string telefone, Guid? idIgnorado = null)
    {
        return registros.Any(i =>
            i.Id != idIgnorado &&
            i.Telefone.Trim() == telefone.Trim()
        );
    }

    public bool ExisteComCpf(string cpf, Guid? idIgnorado = null)
    {
        string cpfSemMascara = RemoverMascaraCpf(cpf);

        return registros.Any(i =>
            i.Id != idIgnorado &&
            RemoverMascaraCpf(i.Cpf) == cpfSemMascara
        );
    }

    private static string RemoverMascaraCpf(string cpf)
    {
        return cpf.Replace(".", "").Replace("-", "").Trim();
    }

    protected override List<Instrutor> ObterRegistros(ContextoJson contexto)
    {
        return contexto.Instrutores;
    }
}

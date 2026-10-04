using System.Text.RegularExpressions;
using EscolaDeCursos.WebApp.Compartilhado.Dominio;

namespace EscolaDeCursos.WebApp.Modulos.ModuloAluno.Dominio;

public class Aluno : EntidadeBase<Aluno>
{
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string NumeroMatricula { get; set; } = string.Empty;

    public Aluno()
    {
    }

    public Aluno(
        string nome,
        string email
    ) : this()
    {
        Nome = nome;
        Email = email;
        NumeroMatricula = GerarNumeroMatricula();
    }

    private static string GerarNumeroMatricula()
    {
        // Guid v4 (aleatório): os primeiros caracteres do v7 são timestamp e se repetem em cadastros próximos
        return "ALU-" + Guid.NewGuid().ToString("N")[..8].ToUpperInvariant();
    }

    public override List<string> Validar()
    {
        List<string> erros = [];

        if (string.IsNullOrWhiteSpace(Nome) || Nome.Length < 3 || Nome.Length > 100)
            erros.Add("O campo \"Nome\" deve conter entre 3 e 100 caracteres.");

        if (!Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            erros.Add("O campo \"E-mail\" deve conter um endereço de e-mail válido.");

        return erros;
    }

    public override void Atualizar(Aluno entidadeAtualizada)
    {
        Nome = entidadeAtualizada.Nome;
        Email = entidadeAtualizada.Email;
    }
}

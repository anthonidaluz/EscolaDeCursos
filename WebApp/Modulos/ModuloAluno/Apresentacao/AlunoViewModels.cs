using System.ComponentModel.DataAnnotations;

namespace EscolaDeCursos.WebApp.Modulos.ModuloAluno.Apresentacao;

public record ListarAlunoViewModel(
    Guid Id,
    string Nome,
    string Email,
    string Cpf,
    string NumeroMatricula
);

public record CadastrarAlunoViewModel(
    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo \"Nome\" deve conter entre 3 e 100 caracteres.")]
    string Nome,

    [Required(ErrorMessage = "O campo \"E-mail\" deve ser preenchido.")]
    [EmailAddress(ErrorMessage = "O campo \"E-mail\" deve conter um endereço de e-mail válido.")]
    string Email,

    [Required(ErrorMessage = "O campo \"CPF\" deve ser preenchido.")]
    [RegularExpression(@"^(\d{3}\.\d{3}\.\d{3}-\d{2}|\d{11})$", ErrorMessage = "O campo \"CPF\" deve estar no formato 000.000.000-00 ou conter 11 dígitos.")]
    string Cpf
);

public record EditarAlunoViewModel(
    Guid Id,

    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo \"Nome\" deve conter entre 3 e 100 caracteres.")]
    string Nome,

    [Required(ErrorMessage = "O campo \"E-mail\" deve ser preenchido.")]
    [EmailAddress(ErrorMessage = "O campo \"E-mail\" deve conter um endereço de e-mail válido.")]
    string Email,

    [Required(ErrorMessage = "O campo \"CPF\" deve ser preenchido.")]
    [RegularExpression(@"^(\d{3}\.\d{3}\.\d{3}-\d{2}|\d{11})$", ErrorMessage = "O campo \"CPF\" deve estar no formato 000.000.000-00 ou conter 11 dígitos.")]
    string Cpf
);

public record ExcluirAlunoViewModel(
    Guid Id,
    string Nome,
    string Email,
    string Cpf,
    string NumeroMatricula
);

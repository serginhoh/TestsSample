using FluentValidation;
using TestsSample.Models;

namespace TestsSample.Validators;

public class PessoaValidator : AbstractValidator<Pessoa>
{
    public PessoaValidator()
    {
        //Nome não pode ser Null ou Vazio
        RuleFor(r => r.Nome).NotNull().NotEmpty();

        //Maior de 18 anos
        RuleFor(r => r.Aniversario).LessThan(DateTime.Now.AddYears(-18))
            .WithMessage("Pessoa deve ser maior de 18 anos.");
    }
}

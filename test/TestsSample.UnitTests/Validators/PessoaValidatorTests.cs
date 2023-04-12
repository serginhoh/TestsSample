using FluentValidation;
using FluentValidation.TestHelper;
using TestsSample.Models;

namespace TestsSample.Validators.Tests;

public class PessoaValidatorTests : IClassFixture<PessoaValidator>
{
    private readonly IValidator<Pessoa> _validator;

    public PessoaValidatorTests(PessoaValidator validator)
    {
        _validator = validator;
    }

    [Fact()]
    public void PessoaValidator_Deve_Retornar_Sem_Erros()
    {
        //arrange
        Pessoa pessoa = new() { Nome = "Nome Teste Ok", Aniversario = new DateTime(2000, 1, 1) };

        //act
        var result = _validator.TestValidate(pessoa);

        //assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact]
    public void PessoaValidator_Deve_Retornar_Erro_Nome_Null()
    {
        //arrange
        Pessoa pessoa = new() { Nome = null, Aniversario = new DateTime(2000, 1, 1) };

        //act
        var result = _validator.TestValidate(pessoa);

        //assert
        result.ShouldHaveValidationErrorFor(i => i.Nome);
    }

    [Fact]
    public void PessoaValidator_Deve_Retornar_Erro_Nome_Vazio()
    {
        //arrange
        Pessoa pessoa = new() { Nome = "", Aniversario = new DateTime(2000, 1, 1) };

        //act
        var result = _validator.TestValidate(pessoa);

        //assert
        result.ShouldHaveValidationErrorFor(i => i.Nome);
    }

    [Fact]
    public void PessoaValidator_Deve_Retornar_Erro_Menor_18_Anos()
    {
        //arrange
        Pessoa pessoa = new() { Nome = "Nome Ok", Aniversario = DateTime.Now };

        //act
        var result = _validator.TestValidate(pessoa);

        //assert
        result.ShouldHaveValidationErrorFor(i => i.Aniversario);
    }
}
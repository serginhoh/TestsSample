using FluentValidation;
using FluentValidation.TestHelper;
using System.Runtime.CompilerServices;
using TestsSample.Models;
using Xunit;

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
        //Arrange
        Pessoa pessoa = new() { Nome = "Nome Usuário", Aniversario = new DateTime(2000, 1, 1) };

        //Act
        var result = _validator.TestValidate(pessoa);

        //Assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    [Fact()]
    public void PessoaValidator_Deve_Retornar_Erro_Nome_Null()
    {
        //Arrange
        Pessoa pessoa = new() { Nome = null, Aniversario = new DateTime(2000, 1, 1) };

        //Act
        var result = _validator.TestValidate(pessoa);

        //Assert
        result.ShouldHaveValidationErrorFor(i => i.Nome);
    }

    [Fact()]
    public void PessoaValidator_Deve_Retornar_Erro_Nome_Vazio()
    {
        //Arrange
        Pessoa pessoa = new() { Nome = "", Aniversario = new DateTime(2000, 1, 1) };

        //Act
        var result = _validator.TestValidate(pessoa);

        //Assert
        result.ShouldHaveValidationErrorFor(i => i.Nome);
    }

    [Fact()]
    public void PessoaValidator_Deve_Retornar_Erro_Menor_18_Anos()
    {
        //Arrange
        Pessoa pessoa = new() { Nome = "Nome do Usuário", Aniversario = DateTime.Now };

        //Act
        var result = _validator.TestValidate(pessoa);

        //Assert
        result.ShouldHaveValidationErrorFor(i => i.Aniversario);
    }
}
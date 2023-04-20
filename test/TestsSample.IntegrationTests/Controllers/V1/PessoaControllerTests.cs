using FluentValidation;
using TestsSample.Interfaces;
using TestsSample.Models;
using TestsSample.Services;
using TestsSample.Validators;

namespace TestsSample.Controllers.V1.Tests;

public class PessoaControllerTests
{
    private readonly IPessoaService _service;

    public PessoaControllerTests()
    {
        IValidator<Pessoa> validator = new PessoaValidator();
        _service = new PessoaService(validator);
    }

    [Fact()]
    public async Task PostPessoa_Deve_Retornar_Pessoa()
    {
        //Arrange
        Pessoa pessoa = new() { Nome = "Nome Usuário", Aniversario = new DateTime(2000, 1, 1) };
        PessoaController controller = new();

        //Act
        var result = await controller.PostPessoa(_service, pessoa);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(pessoa, result);
        Assert.IsAssignableFrom<Pessoa>(pessoa);
    }

    [Fact()]
    public async Task PostPessoa_Deve_Retornar_Erro_Menor_De_Idade()
    {
        //Arrange
        Pessoa pessoa = new () { Nome = "Nome Usuário", Aniversario = DateTime.Now };
        PessoaController controller = new();
        string message = "Validation failed: \r\n -- Aniversario: Pessoa deve ser maior de 18 anos. Severity: Error";

        ////Act
        var result = await Assert.ThrowsAsync<ValidationException>(() => controller.PostPessoa(_service, pessoa));

        //Assert
        Assert.NotNull(result);
        Assert.Equal(message, result.Message);
    }
}
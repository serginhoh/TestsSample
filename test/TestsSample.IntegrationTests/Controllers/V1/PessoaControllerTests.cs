using FluentValidation;
using TestsSample.Interfaces;
using TestsSample.Models;
using TestsSample.Services;
using TestsSample.Validators;

namespace TestsSample.Controllers.V1.Tests;

public class PessoaControllerTests : IClassFixture<PessoaValidator>
{
    private readonly IValidator<Pessoa> _validator;
    private readonly IPessoaService _service;

    public PessoaControllerTests(PessoaValidator validator)
    {
        _validator = validator;
        _service = new PessoaService(_validator);
    }

    [Fact()]
    public async Task PostPessoa_Deve_Retornar_Pessoa()
    {
        //Arrange
        Pessoa pessoa = new() { Nome = "Nome Teste", Aniversario = new DateTime(2000, 1, 1) };
        PessoaController controller = new();

        //Act
        var result = await controller.PostPessoa(_service, pessoa);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(result, pessoa);
    }

    [Fact()]
    public async Task PostPessao_Deve_Retornar_Erro_Menor_De_Idade()
    {
        //arrange
        Pessoa pessoa = new() { Nome = "Nome Teste", Aniversario = DateTime.Now };
        string message = "Validation failed: \r\n -- Aniversario: Pessoa deve ser maior de 18 anos. Severity: Error";

        //Act
        var result = await Assert.ThrowsAsync<ValidationException>(() => _service.AdicionaPessoa(pessoa));

        //Assert
        Assert.NotNull(result);
        Assert.Equal(message, result.Message);
    }
}
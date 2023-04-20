using FluentValidation;
using Moq;
using TestsSample.Interfaces;
using TestsSample.Models;

namespace TestsSample.Services.Tests;

public class PessoaServiceTests
{
    [Fact()]
    public async Task AdicionaPessoa_Deve_Retornar_Pessoa()
    {
        //Arrange
        InlineValidator<Pessoa> validator = new();
        IPessoaService service = new PessoaService(validator);
        Pessoa pessoa = new();

        //Act
        var result = await service.AdicionaPessoa(pessoa);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(pessoa, result);
        Assert.IsAssignableFrom<Pessoa>(result);

    }

    [Fact()]
    public async Task AdicionaPessoa_Deve_Retornar_Pessoa_MOQ()
    {
        //Arrange
        Mock<IValidator<Pessoa>> validator = new();
        IPessoaService service = new PessoaService(validator.Object);
        Pessoa pessoa = new();

        //Act
        var result = await service.AdicionaPessoa(pessoa);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(pessoa, result);
        Assert.IsAssignableFrom<Pessoa>(result);
    }
}
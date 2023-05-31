using FluentAssertions;
using Moq;
using TestsSample.Interfaces;
using TestsSample.Models;

namespace TestsSample.Controllers.V1.Tests;

public class PessoaControllerTests
{
    [Fact()]
    public async Task PostPessoa_Deve_Retornar_Pessoa()
    {
        //Arrange
        Pessoa pessoa = new() { Nome = "Nome Usuário", Aniversario = new DateTime(2000, 1, 1) };
        Mock<IPessoaService> service = new();
        service.Setup(_ => _.AdicionaPessoa(It.IsAny<Pessoa>())).ReturnsAsync(pessoa);
        PessoaController controller = new();

        //Act
        var result = await controller.PostPessoa(service.Object, pessoa);

        //Assert
        Assert.NotNull(result );
        Assert.Equal(pessoa, result);
        Assert.IsAssignableFrom<Pessoa>(result);
    }

    [Fact()]
    public async Task PostPessoa_Deve_Retornar_Pessoa_FluentAssertions()
    {
        //Arrange
        Pessoa pessoa = new() { Nome = "Nome Usuário", Aniversario = new DateTime(2000, 1, 1) };
        Mock<IPessoaService> service = new();
        service.Setup(_ => _.AdicionaPessoa(It.IsAny<Pessoa>())).ReturnsAsync(pessoa);
        PessoaController controller = new();

        //Act
        var result = await controller.PostPessoa(service.Object, pessoa);

        //Assert
        result.Should().NotBeNull().And.Be(pessoa).And.BeAssignableTo<Pessoa>();
    }
}
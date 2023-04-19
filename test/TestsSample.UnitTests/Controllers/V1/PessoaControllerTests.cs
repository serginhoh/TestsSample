using TestsSample.Interfaces;
using TestsSample.Models;
using Moq;

namespace TestsSample.Controllers.V1.Tests;

public class PessoaControllerTests
{
    [Fact()]
    public async Task PostPessoa_Deve_Retornar_Pessoa()
    {
        //Arrange
        Pessoa pessoa = new() { Nome = "Nome Teste", Aniversario = new DateTime(2000, 1, 1) };
        Mock<IPessoaService> moqService = new();
        moqService.Setup(_ => _.AdicionaPessoa(It.IsAny<Pessoa>())).ReturnsAsync(pessoa);
        PessoaController controller = new();

        //Act
        var result = await controller.PostPessoa(moqService.Object, pessoa);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(result, pessoa);
        Assert.IsAssignableFrom<Pessoa>(result);
    }
}
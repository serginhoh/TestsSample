using Moq;
using TestsSample.Interfaces;
using TestsSample.Models;

namespace TestsSample.Controllers.V2.Tests
{
    public class PessoaControllerTests
    {

        [Fact()]
        public async Task PostPessoa_Deve_Retornar_Pessoa()
        {
            //Arrange
            Pessoa pessoa = new() { Nome = "Nome Teste", Aniversario = new DateTime(2000, 1, 1) };
            Mock<IPessoaService> moqService = new();
            moqService.Setup(_ => _.AdicionaPessoa(It.IsAny<Pessoa>())).ReturnsAsync(pessoa);
            PessoaController controller = new(moqService.Object);

            //Act
            var result = await controller.PostPessoa(pessoa);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result, pessoa);
            Assert.IsAssignableFrom<Pessoa>(result);
        }
    }
}
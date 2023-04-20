using Xunit;
using TestsSample.Controllers.V2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            //arrange
            Pessoa pessoa = new() { Nome = "Nome Usuário", Aniversario = new DateTime(2000, 1, 1) };
            Mock<IPessoaService> service = new();
            service.Setup(_ => _.AdicionaPessoa(It.IsAny<Pessoa>())).ReturnsAsync(pessoa);
            PessoaController controller = new(service.Object);

            //Act
            var result = await controller.PostPessoa(pessoa);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(pessoa, result);
            Assert.IsAssignableFrom<Pessoa>(result);
        }
    }
}
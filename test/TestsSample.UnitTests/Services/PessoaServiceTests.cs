using FluentValidation;
using TestsSample.Interfaces;
using TestsSample.Models;

namespace TestsSample.Services.Tests;

public class PessoaServiceTests
{
    [Fact()]
    public async Task AdicionaPessoa_Deve_Retornar_Pessoa()
    {
        //arrange
        InlineValidator<Pessoa> validator = new();
        IPessoaService service = new PessoaService(validator);
        Pessoa pessoa = new() { Nome = "Nome Teste", Aniversario = new DateTime(2000, 1, 1) };

        //Act
        var result = await service.AdicionaPessoa(pessoa);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(pessoa, result);
        Assert.IsAssignableFrom<Pessoa>(result);
    }
}
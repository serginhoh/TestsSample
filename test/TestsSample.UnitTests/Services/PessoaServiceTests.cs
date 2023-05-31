using FluentAssertions;
using FluentAssertions.Execution;
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
        Pessoa pessoa = new() { Nome = "Nome Teste", Aniversario = new DateTime(2000, 1, 1) };

        //Act
        var result = await service.AdicionaPessoa(pessoa);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(pessoa, result);
        Assert.IsAssignableFrom<Pessoa>(result);
    }

    [Fact()]
    public async Task AdicionaPessoa_Deve_Retornar_Pessoa_FluentAssertions()
    {
        //Arrange
        InlineValidator<Pessoa> validator = new();
        IPessoaService service = new PessoaService(validator);
        Pessoa pessoa = new() { Nome = "Nome Teste", Aniversario = new DateTime(2000, 1, 1) };

        //Act
        var result = await service.AdicionaPessoa(pessoa);

        //Assert
        result.Should().NotBeNull().And.Be(pessoa).And.BeAssignableTo<Pessoa>();
    }

    [Fact()]
    public async Task AdicionaPessoa_Deve_Retornar_Pessoa_FluentAssertions_AssertionScope()
    {
        //Arrange
        InlineValidator<Pessoa> validator = new();
        IPessoaService service = new PessoaService(validator);
        Pessoa pessoa = new() { Nome = "Nome Teste", Aniversario = new DateTime(2000, 1, 1) };

        //Act
        var result = await service.AdicionaPessoa(pessoa);

        //Assert
        using (new AssertionScope())
        {
            result.Should().NotBeNull();
            result.Should().Be(pessoa);
            result.Should().BeAssignableTo<Pessoa>();
        }
    }

    [Fact()]
    public async Task AdicionaPessoa_Deve_Retornar_Pessoa_Moq_Validator()
    {
        //Arrange
        Mock<IValidator<Pessoa>> validator = new();
        IPessoaService service = new PessoaService(validator.Object);
        Pessoa pessoa = new() { Nome = "Nome Teste", Aniversario = new DateTime(2000, 1, 1) };

        //Act
        var result = await service.AdicionaPessoa(pessoa);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(pessoa, result);
        Assert.IsAssignableFrom<Pessoa>(result);
    }

    [Fact()]
    public async Task AdicionaPessoa_Deve_Retornar_Pessoa_Moq_Validator_FluentAssertions()
    {
        //Arrange
        Mock<IValidator<Pessoa>> validator = new();
        IPessoaService service = new PessoaService(validator.Object);
        Pessoa pessoa = new() { Nome = "Nome Teste", Aniversario = new DateTime(2000, 1, 1) };

        //Act
        var result = await service.AdicionaPessoa(pessoa);

        //Assert
        result.Should().NotBeNull().And.Be(pessoa).And.BeAssignableTo<Pessoa>();
    }

    [Fact()]
    public async Task AdicionaPessoa_Deve_Retornar_Erro()
    {
        //Arrange
        InlineValidator<Pessoa> validator = new();
        validator.RuleFor(i => i.Nome).Must(i => false);
        IPessoaService service = new PessoaService(validator);
        Pessoa pessoa = new() { };

        //Act
        var result = await Assert.ThrowsAsync<ValidationException>(() => service.AdicionaPessoa(pessoa));

        //Assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<ValidationException>(result);
    }
    [Fact()]
    public async Task AdicionaPessoa_Deve_Retornar_Erro_FluentAssertions()
    {
        //Arrange
        InlineValidator<Pessoa> validator = new();
        validator.RuleFor(i => i.Nome).Must(i => false);
        IPessoaService service = new PessoaService(validator);
        Pessoa pessoa = new() { };

        //Act
        Func<Task> act = () => service.AdicionaPessoa(pessoa);

        //Assert
        await act.Should().ThrowExactlyAsync<ValidationException>();
    }
}
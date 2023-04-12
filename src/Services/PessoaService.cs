using FluentValidation;
using TestsSample.Interfaces;
using TestsSample.Models;

namespace TestsSample.Services;

public class PessoaService : IPessoaService
{
    private readonly IValidator<Pessoa> _validator;

    public PessoaService(IValidator<Pessoa> validator)
    {
        _validator = validator;
    }

    public async Task<Pessoa> AdicionaPessoa(Pessoa pessoa)
    {
        await _validator.ValidateAndThrowAsync(pessoa);

        return pessoa;
    }
}

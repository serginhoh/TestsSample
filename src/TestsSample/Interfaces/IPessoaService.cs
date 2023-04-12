using TestsSample.Models;

namespace TestsSample.Interfaces;

public interface IPessoaService
{
    public Task<Pessoa> AdicionaPessoa(Pessoa pessoa);
}
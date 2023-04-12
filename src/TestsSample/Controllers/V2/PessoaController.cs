using Microsoft.AspNetCore.Mvc;
using System.Net;
using TestsSample.Interfaces;
using TestsSample.Models;

namespace TestsSample.Controllers.V2;

[Route("v{version:apiVersion}/[controller]")]
[ApiController]
public class PessoaController : ControllerBase
{
    private readonly IPessoaService _pessoaService;

    public PessoaController(IPessoaService pessoaService)
    {
        _pessoaService = pessoaService;
    }
    [HttpPost]
    [ApiVersion("2.0")]
    [ProducesResponseType(typeof(Pessoa), (int)HttpStatusCode.OK)]
    public async Task<Pessoa> PostPessoa(Pessoa pessoa)
    {
        return await _pessoaService.AdicionaPessoa(pessoa);
    }
}

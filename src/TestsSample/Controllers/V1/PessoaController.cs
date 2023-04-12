using Microsoft.AspNetCore.Mvc;
using System.Net;
using TestsSample.Interfaces;
using TestsSample.Models;

namespace TestsSample.Controllers.V1;

[Route("v{version:apiVersion}/[controller]")]
[ApiController]
public class PessoaController : ControllerBase
{
    [HttpPost]
    [ApiVersion("1.0")]
    [ProducesResponseType(typeof(Pessoa), (int)HttpStatusCode.OK)]
    public async Task<Pessoa> PostPessoa([FromServices] IPessoaService pessoaService, Pessoa pessoa)
    {
        return await pessoaService.AdicionaPessoa(pessoa);
    }
}

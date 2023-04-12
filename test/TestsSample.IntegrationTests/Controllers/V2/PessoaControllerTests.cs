using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TestsSample.Models;

namespace TestsSample.Controllers.V2.Tests;

public class PessoaControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public PessoaControllerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Post_V2_Pessoa_Deve_Retornar_Pessoa_HttpStatusCode_OK()
    {
        using HttpClient client = _factory.CreateClient();
        Pessoa pessoa = new() { Nome = "Teste", Aniversario = new DateTime(2000, 1, 1) };
        StringContent postBody = new(JsonConvert.SerializeObject(pessoa));
        postBody.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        HttpResponseMessage response = await client.PostAsync("v2/Pessoa", postBody);
        string data = await response.Content.ReadAsStringAsync();
        Assert.NotNull(response);
        Assert.NotNull(data);
        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task Post_V2_Pessoa_Deve_Retornar_Erro_Nome_Null_HttpStatusCode_InternalServerError()
    {
        using HttpClient client = _factory.CreateClient();
        Pessoa pessoa = new() { Nome = null, Aniversario = new DateTime(2000, 1, 1) };
        StringContent postBody = new(JsonConvert.SerializeObject(pessoa));
        postBody.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        HttpResponseMessage response = await client.PostAsync("v2/Pessoa", postBody);
        string data = await response.Content.ReadAsStringAsync();
        Assert.NotNull(response);
        Assert.NotNull(data);
        Assert.Equal(System.Net.HttpStatusCode.InternalServerError, response.StatusCode);
    }

    [Fact]
    public async Task Post_V2_Pessoa_Deve_Retornar_Erro_Nome_Vazio_HttpStatusCode_InternalServerError()
    {
        using HttpClient client = _factory.CreateClient();
        Pessoa pessoa = new() { Nome = "", Aniversario = new DateTime(2000, 1, 1) };
        StringContent postBody = new(JsonConvert.SerializeObject(pessoa));
        postBody.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        HttpResponseMessage response = await client.PostAsync("v2/Pessoa", postBody);
        string data = await response.Content.ReadAsStringAsync();
        Assert.NotNull(response);
        Assert.NotNull(data);
        Assert.Equal(System.Net.HttpStatusCode.InternalServerError, response.StatusCode);
    }
}

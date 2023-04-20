using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
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

    [Fact()]
    public async Task PostPessoa_Deve_Retornar_HttpStatusCode_OK()
    {
        //arrange
        using HttpClient client = _factory.CreateClient();
        Pessoa pessoa = new() { Nome = "Nome do Usuário", Aniversario = new DateTime(2000, 1, 1) };
        StringContent postBody = new(JsonConvert.SerializeObject(pessoa));
        postBody.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        //Act
        HttpResponseMessage response = await client.PostAsync("v2/Pessoa", postBody);
        string data = await response.Content.ReadAsStringAsync();
        Pessoa? result = JsonConvert.DeserializeObject<Pessoa?>(data);

        //Assert
        Assert.NotNull(response);
        Assert.NotNull(data);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.IsAssignableFrom<Pessoa>(result);
    }

    [Fact()]
    public async Task PostPessoa_Deve_Retornar_HttpStatusCode_InternalError()
    {
        //arrange
        using HttpClient client = _factory.CreateClient();
        Pessoa pessoa = new() { Nome = null, Aniversario = new DateTime(2000, 1, 1) };
        StringContent postBody = new(JsonConvert.SerializeObject(pessoa));
        postBody.Headers.ContentType = new MediaTypeHeaderValue("application/json");

        //Act
        HttpResponseMessage response = await client.PostAsync("v2/Pessoa", postBody);
        string data = await response.Content.ReadAsStringAsync();

        //Assert
        Assert.NotNull(response);
        Assert.NotNull(data);
        Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
    }

}
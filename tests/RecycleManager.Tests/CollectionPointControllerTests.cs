using RecycleManager.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

public class CollectionPointControllerTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;

    public CollectionPointControllerTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    private async Task AuthenticateAsync()
    {
        
        var tokenResponse = await _client.GetAsync("/api/DevToken/token");
        tokenResponse.EnsureSuccessStatusCode();

        var jsonString = await tokenResponse.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(jsonString);
        var token = doc.RootElement.GetProperty("token").GetString();

        _client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);
    }

    [Fact]
    public async Task PostCollectionPoint_Returns201_WhenAuthorized()
    {
        await AuthenticateAsync();

        var request = "/api/CollectionPoint";

        var body = new
        {
            Name = "Ponto de Coleta Teste",
            Address = "Rua Exemplo, 123"
        };
        var response = await _client.PostAsJsonAsync(request, body);


        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(System.Net.HttpStatusCode.Created, response.StatusCode); 
    }
}

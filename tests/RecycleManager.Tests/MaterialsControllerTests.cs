using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace RecycleManager.Tests;

public class MaterialsControllerTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly CustomWebApplicationFactory _factory;

    public MaterialsControllerTests(CustomWebApplicationFactory factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task Get_ReturnsHttpStatusCode200()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/api/materials?page=1&pageSize=5");
        response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}

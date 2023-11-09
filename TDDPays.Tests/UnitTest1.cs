namespace TDDPays.Tests;

using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

public class UnitTest1
{
    [Fact]
    public async Task IsGetGovernmentOk()
    {
        await using var _factory = new WebApplicationFactory<Program>();
        var client = _factory.CreateClient();
        var response = await client.GetAsync("Government");
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async Task IsGetGovernmentByIdOk()
    {
        await using var _factory = new WebApplicationFactory<Program>();
        var client = _factory.CreateClient();
        var response = await client.GetAsync("Government/FR");
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async Task IsGetGovernmentByIdNotFound()
    {
        await using var _factory = new WebApplicationFactory<Program>();
        var client = _factory.CreateClient();
        var response = await client.GetAsync("Government/XX");
        
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}

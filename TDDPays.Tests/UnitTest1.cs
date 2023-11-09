namespace TDDPays.Tests;

using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

public class UnitTest1
{
    /*
     * GIVEN je récupère la liste des gouvernements
     * WHEN je demande la liste des gouvernements
     * THEN je reçois une liste de gouvernements (format liste de json)
     * AND je reçois un code 200
     */
    [Fact]
    public async Task IsGetGovernmentOk()
    {
        await using var _factory = new WebApplicationFactory<Program>();
        var client = _factory.CreateClient();
        var response = await client.GetAsync("Government");
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    /*
     * GIVEN je récupère le gouvernement de la France
     * WHEN je fais un appel GET sur /Government/FR
     * THEN je reçois un json sous la forme { "id": "FR", "name": "Semi-presidential republic"}
     * AND je reçois un code 200
     */
    
    [Fact]
    public async Task IsGetGovernmentByIdFROk()
    {
        await using var _factory = new WebApplicationFactory<Program>();
        var client = _factory.CreateClient();
        var response = await client.GetAsync("Government/FR");
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async Task IsGetGovernmentByIdFRReturning()
    {
        await using var _factory = new WebApplicationFactory<Program>();
        var client = _factory.CreateClient();
        var response = await client.GetAsync("Government/FR");
        
        
        Assert.Equal("{\"id\":\"FR\",\"name\":\"Semi-presidential republic\"}", await response.Content.ReadAsStringAsync());
    }
    
    /*
     * GIVEN je récupère le gouvernement d'un pays inexistant
     * WHEN je fais un appel GET sur /Government/XX
     * THEN je reçois un code 404
     */
    
    [Fact]
    public async Task IsGetGovernmentByIdNotFound()
    {
        await using var _factory = new WebApplicationFactory<Program>();
        var client = _factory.CreateClient();
        var response = await client.GetAsync("Government/XX");
        
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
    
    /*
     * GIVEN je récupère le gouvernement d'un pays qui n'a pas de gouvernement
     * WHEN je fais un appel GET sur /Government/PL
     * THEN je reçois un code 204
     */
    
    [Fact]
    public async Task IsGetGovernmentByIdNoContent()
    {
        await using var _factory = new WebApplicationFactory<Program>();
        var client = _factory.CreateClient();
        var response = await client.GetAsync("Government/PL");
        
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }
}

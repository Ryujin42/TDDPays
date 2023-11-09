using ChoETL;
using Microsoft.AspNetCore.Mvc;

namespace TDDPays.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class GovernmentController : ControllerBase
{
    private readonly ILogger<GovernmentController> _logger;

    public GovernmentController(ILogger<GovernmentController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetGovernment")]
    public async Task<IActionResult> GetAsync()
    {
        var results = new List<Government>();
        
        using (var reader = new ChoCSVReader(AppDomain.CurrentDomain.BaseDirectory + "../../../government.csv")
                   .WithFirstLineHeader().WithDelimiter(","))
        {
            foreach (var government in reader)
            {
                var result = new Government
                {
                    Id = government.Id,
                    Name = government.Name
                };
                results.Add(result);
            }
        }
        
        if (!results.Any()) return NotFound();
        return Ok(results);
    }
    
    [HttpGet("{id}", Name = "GetGovernmentById")]
    public async Task<IActionResult> GetAsyncById(string id)
    {
        using (var reader = new ChoCSVReader(
                   AppDomain.CurrentDomain.BaseDirectory + "../../../government.csv")
                   .WithFirstLineHeader().WithDelimiter(","))
        {
            foreach (var government in reader)
            {
                if (government.Id == id)
                {
                    var result = new Government
                    {
                        Id = government.Id,
                        Name = government.Name
                    };
                    return Ok(result);
                }
            }
        }
        return NotFound();
    }
}

using Microsoft.AspNetCore.Mvc;

namespace DesafioDistribuicaoDosLucros.API.Controllers;

[ApiController]
[Route("health")]
public class HealthController : ControllerBase
{
    [HttpGet(Name = "/")]
    public IActionResult Get()
    {
        return Ok("O servidor está online");
    }
}

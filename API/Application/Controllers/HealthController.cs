using Microsoft.AspNetCore.Mvc;

namespace DesafioDistribuicaoDosLucros.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("O servidor está online");
    }
}

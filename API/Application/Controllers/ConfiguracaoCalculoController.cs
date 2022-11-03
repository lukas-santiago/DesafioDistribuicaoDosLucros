using Application.Models;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ConfiguracaoCalculoController : ControllerBase
{
    public IConfiguracaoCalculoService _configuracaoCalculoService { get; }
    public ConfiguracaoCalculoController(IConfiguracaoCalculoService configuracaoCalculoService)
    {
        _configuracaoCalculoService = configuracaoCalculoService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(_configuracaoCalculoService.Get());
    }

    [HttpPut]
    public async Task<IActionResult> Edit([FromBody] ConfiguracaoCalculo request)
    {
        return Ok(_configuracaoCalculoService.Edit(request));
    }
}

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

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _configuracaoCalculoService.GetAll());
    }
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _configuracaoCalculoService.Get());
    }

    [HttpPut]
    public async Task<IActionResult> Edit([FromBody] ConfiguracaoCalculo request)
    {
        await _configuracaoCalculoService.Edit(request);
        return Ok();
    }
}

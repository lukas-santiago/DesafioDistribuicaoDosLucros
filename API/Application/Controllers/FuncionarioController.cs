using Application.Models;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class FuncionarioController : ControllerBase
{
    public IFuncionarioService _funcionarioService { get; }
    public FuncionarioController(IFuncionarioService funcionarioService)
    {
        _funcionarioService = funcionarioService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _funcionarioService.GetAll());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        return Ok(await _funcionarioService.Get(id));
    }

    [HttpPost("")]
    public async Task<IActionResult> Add([FromBody] Funcionario funcionario)
    {
        return Ok(await _funcionarioService.Add(funcionario));
    }

    [HttpPut("")]
    public async Task<IActionResult> Edit([FromBody] Funcionario funcionario)
    {
        return Ok(await _funcionarioService.Edit(funcionario));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _funcionarioService.Delete(id);
        return Ok();
    }
}

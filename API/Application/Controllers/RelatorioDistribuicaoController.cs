using Application.Models;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class RelatorioDistribuicaoController : ControllerBase
{
    public IRelatorioDistribuicaoService _relatorioDistribuicaoService { get; }
    public RelatorioDistribuicaoController(IRelatorioDistribuicaoService relatorioDistribuicaoService)
    {
        _relatorioDistribuicaoService = relatorioDistribuicaoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _relatorioDistribuicaoService.GetAll());
    }
    [HttpGet("GetLast")]
    public async Task<IActionResult> GetLast()
    {
        return Ok(await _relatorioDistribuicaoService.GetLast());
    }
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        return Ok(await _relatorioDistribuicaoService.GetById(id));
    }

    [HttpPost]
    public async Task<IActionResult> Generate()
    {
        return Ok(await _relatorioDistribuicaoService.Generate());
    }
}

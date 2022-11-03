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
        return Ok(_relatorioDistribuicaoService.GetAll());
    }
    [HttpGet("GetLast")]
    public async Task<IActionResult> GetLast()
    {
        return Ok(_relatorioDistribuicaoService.GetLast());
    }

    [HttpPost]
    public async Task<IActionResult> Edit()
    {
        return Ok(_relatorioDistribuicaoService.Calculate());
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeGestão.Data;
using SistemaDeGestão.Models;
using SistemaDeGestão.Services;

namespace SistemaDeGestão.Controllers
{
    public class MovimentacaoController : Controller
    {
        private readonly MovimentacaoService _movimentacaoService;
        public MovimentacaoController(MovimentacaoService movimentacaoService)
        {
            _movimentacaoService = movimentacaoService;
        }
        public async Task<IActionResult> get()
        {
            return Ok(await _movimentacaoService.ListarMovimentacoes());
        }
        public IActionResult Post([FromBody] Movimentacao mov)
        {
            _movimentacaoService.AdicionaMovimentacao(mov);
            return Ok("Movimentacao enviada");
        }
    }
}

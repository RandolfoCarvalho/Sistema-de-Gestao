using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeGestão.Data;
using SistemaDeGestão.Models;
using SistemaDeGestão.Services;


namespace SistemaDeGestão.Controllers
{

    public class ProdutoController : Controller
    {
        public readonly ProdutoService _produtoService;
        public readonly DataBaseContext _context;
        public ProdutoController(DataBaseContext context, ProdutoService produtoService)
        {
            _produtoService = produtoService;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Produto> produtos = await _produtoService.ListarProdutos();
            return View(produtos);
        }
        public async Task<IActionResult> list()
        {
            List<Produto> produtos = await _produtoService.ListarProdutos();
            return Ok(produtos);
        }
        public IActionResult Post([FromBody] Produto produto)
        {
            _produtoService.AdicionarProduto(produto);
            return Ok("Produto adicionado com sucesso");
        }
        public IActionResult Put([FromBody] Produto produto)
        {
           _produtoService.AtualizarProduto(produto);
            return Ok("Produto atualizado com sucesso");
        }
        public IActionResult Delete(int id)
        {
            _produtoService.DeletarProduto(id);
            return Ok("Produto deletado com sucesso");
        }
        public IActionResult Detalhes(int id)
        {
            var produto = _produtoService.ObterProdutoPorId(id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }
    }
}

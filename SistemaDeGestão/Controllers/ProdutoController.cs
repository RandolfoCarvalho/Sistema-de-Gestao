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
        public ProdutoController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }
        public async Task<IActionResult> Index()
        {
            List<Produto> produtos = await _produtoService.ListarProdutos();
            return View(produtos);
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
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeGestão.Data;
using SistemaDeGestão.Models;
using SistemaDeGestão.Models.ViewModel;
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
        [HttpGet]
        public IActionResult CriarProduto()
        {
            var viewModel = new ProdutoViewModel();
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken] // Para proteção CSRF
        public IActionResult CriarProduto(ProdutoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var novoProduto = new Produto
                {
                    Nome = viewModel.Nome,
                    Descricao = viewModel.Descricao,
                    Preco = viewModel.Preco,
                    ProductImage = viewModel.ProductImage,
                    CategoriaId = viewModel.CategoriaId,
                    QuantidadeEstoque = viewModel.QuantidadeEstoque
                };
                _produtoService.AdicionarProduto(novoProduto);
                return RedirectToAction("Index", "Produto");
            }
            return View(viewModel);
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

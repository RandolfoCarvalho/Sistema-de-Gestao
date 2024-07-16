using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public readonly CategoriaService _categoriaService;
        public ProdutoController(DataBaseContext context, ProdutoService produtoService, CategoriaService categoriaService)
        {
            _produtoService = produtoService;
            _context = context;
            _categoriaService = categoriaService;
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
            var model = new ProdutoViewModel
            {
                Categorias = _context.Categorias.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),  // O valor será o nome da categoria
                    Text = c.Nome    // O texto exibido será o nome da categoria
                }).ToList()
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken] // Para proteção CSRF
        public IActionResult CriarProduto(ProdutoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var novoProduto = new Produto
                {
                    CategoriaId = viewModel.CategoriaId,
                    Nome = viewModel.Nome,
                    Descricao = viewModel.Descricao,
                    Preco = viewModel.Preco,
                    ProductImage = viewModel.ProductImage,
                    QuantidadeEstoque = viewModel.QuantidadeEstoque
                };
                _produtoService.AdicionarProduto(novoProduto);
                return RedirectToAction("Index", "Produto");
            }
            viewModel.Categorias = _context.Categorias.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),  // O valor será o ID da categoria
                Text = c.Nome             // O texto exibido será o nome da categoria
            }).ToList();
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

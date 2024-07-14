using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeGestão.Data;
using SistemaDeGestão.Models;
using SistemaDeGestão.Services;

namespace SistemaDeGestão.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly CategoriaService _categoriaService;
        public CategoriaController(CategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }
        public async Task<IActionResult> FindAll()
        { 
            List<Categoria> categorias = await _categoriaService.ListarCategorias();
            return Ok(categorias);
        }
        public async Task<IActionResult> Post([FromBody] Categoria categoria)
        {
           _categoriaService.AdicionarCategoria(categoria);
            return Ok("Categoria Criada com sucesso");
        }
        public IActionResult Put([FromBody] Categoria categoria)
        {
            _categoriaService.AtualizarCategoria(categoria);
            return Ok("Categoria Atualizada com sucesso");
        }
        public IActionResult Delete(int id)
        {
            _categoriaService.DeletarCategoria(id);
            return Ok("Categoria deletada com sucesso");
        }
    }
}

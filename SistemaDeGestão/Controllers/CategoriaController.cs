using Microsoft.AspNetCore.Mvc;
using SistemaDeGestão.Data;
using SistemaDeGestão.Models;

namespace SistemaDeGestão.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly DataBaseContext _context;
        public CategoriaController(DataBaseContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> getAll()
        {
            var result = _context.Categorias.ToList();
            return Ok(result);
        }
        public IActionResult Post([FromBody] Categoria categoria)
        {
            try
            {
                _context.Add(categoria);
                _context.SaveChanges();
                return Ok(categoria);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public IActionResult Put([FromBody] Categoria categoria)
        {
            var current = _context.Categorias.FirstOrDefault(p => p.Id == categoria.Id);
            if (current == null) return BadRequest("Não foi possivel localizar a categoria");
            try
            {
                _context.Entry(current).CurrentValues.SetValues(categoria);
                _context.SaveChanges();
                return Ok(categoria);
            } catch (Exception e)
            {
                throw new Exception("Erro ao atualizar categoria " + e.Message);
            }
        }
        public IActionResult Delete(int id)
        {
            var result = _context.Categorias.FirstOrDefault(p => p.Id == id);
            if (result == null) return BadRequest("Não foi possivel localizar a categoria");
            _context.Categorias.Remove(result);
            _context.SaveChanges();
            return Ok(result);
        }
    }
}

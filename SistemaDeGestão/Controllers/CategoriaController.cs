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

    }
}

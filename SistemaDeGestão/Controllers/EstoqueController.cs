using Microsoft.AspNetCore.Mvc;
using SistemaDeGestão.Data;
using SistemaDeGestão.Models;

namespace SistemaDeGestão.Controllers
{
    public class EstoqueController : Controller
    {
        private readonly DataBaseContext _context;
        public EstoqueController(DataBaseContext context)
        {
            _context = context;
        }

        public IActionResult get()
        {
            var result = _context.Estoques.ToList();
            return Ok(result);
        }
        public IActionResult post([FromBody] Estoque estoque)
        {
            _context.Estoques.Add(estoque);
            _context.SaveChanges();
            return Ok(estoque);
        }
    }
}

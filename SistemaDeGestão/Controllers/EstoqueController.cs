using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var result = _context.Estoques.Include(p => p.Produtos).ToList();
            return Ok(result);
        }
        public IActionResult post([FromBody] Estoque estoque)
        {
            try
            {
                _context.Add(estoque);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar novo estoque" + e.Message);
            }
            return Ok("Estoque criado com sucesso");
        }
    }
}

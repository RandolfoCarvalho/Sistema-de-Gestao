using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeGestão.Data;
using SistemaDeGestão.Models;


namespace SistemaDeGestão.Controllers
{

    public class ProdutoController : Controller
    {
        public readonly DataBaseContext _context;
        public ProdutoController(DataBaseContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            return Ok(_context.Produtos.ToList());
        }
        public IActionResult Post([FromBody] Produto produto)
        {
            try
            {
                _context.Add(produto);
                _context.SaveChanges();
                return Ok(produto);
            } catch (Exception e)
            {
                throw new Exception("Erro ao criar produto" + e.Message);
            }
        }
        public IActionResult Put([FromBody] Produto produto)
        {
            var current = _context.Produtos.FirstOrDefault(p => p.Id == produto.Id);
            if (current == null) return BadRequest("Produto não encontrado");
            try
            {
                _context.Entry(current).CurrentValues.SetValues(produto);
                _context.SaveChanges();
                return Ok(produto);
            }
            catch (Exception e)
            {
                throw new Exception("Não foi possivel atualizar o produto" + e.Message);
            }
        }
        public IActionResult Delete(int id)
        {
            var result = _context.Produtos.FirstOrDefault(p => p.Id.Equals(id));
            if (result == null) return BadRequest("Não foi possivel encontrar o produto especificao ");
            _context.Produtos.Remove(result);
            _context.SaveChanges();
            return Ok(result);
        }
    }
}

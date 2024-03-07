using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeGestão.Data;
using SistemaDeGestão.Models;


namespace SistemaDeGestão.Controllers
{

    public class Produto : Controller
    {
        public readonly DataBaseContext _context;
        public Produto(DataBaseContext context)
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
    }
}

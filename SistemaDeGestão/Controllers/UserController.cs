using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using SistemaDeGestão.Data;
using SistemaDeGestão.Models;

namespace SistemaDeGestão.Controllers
{
    public class UserController : Controller
    {
        private readonly DataBaseContext _context;

        public UserController(DataBaseContext context)
        {
            _context = context;
        }
        /* public UserController(DataBaseContext context)
        {
            _context = context;
        } */
        public IActionResult list()
        {
           return Ok(_context.Users.ToList());
        }
        public IActionResult criarUser([FromBody] User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao criar novo usuario" + e.Message);
            }
            return Ok(user);
        }
        /*
        public IActionResult Autenticar([FromBody] User user)
        {
           

        } */
    }
}

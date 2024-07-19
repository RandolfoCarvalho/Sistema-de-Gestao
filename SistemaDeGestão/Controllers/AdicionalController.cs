using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using SistemaDeGestão.Data;
using SistemaDeGestão.Models;

namespace SistemaDeGestão.Controllers
{
    public class AdicionalController : Controller
    {
        private readonly DataBaseContext _context;
        public AdicionalController(DataBaseContext context) 
        {
            _context = context;
        }
        [HttpPost]
        public JsonResult CriarAdicional(string nome, double Preco) 
        {
            try
            {
                Adicional ad = new Adicional
                {
                    Nome = nome,
                    PrecoAdicional = Preco
                };
                _context.Add(ad);
                _context.SaveChanges();
                return Json(new { success = true });
            } catch (Exception e)
            {
                var errorMessage = e.Message;
                if (e.InnerException != null)
                {
                    errorMessage += " - " + e.InnerException.Message;
                }
                return Json(new { success = false, message = errorMessage });
            }
        }
    }
}

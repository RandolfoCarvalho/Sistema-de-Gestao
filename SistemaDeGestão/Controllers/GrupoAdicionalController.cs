using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeGestão.Models.ViewModel;
using SistemaDeGestão.Models;
using SistemaDeGestão.Data;

namespace SistemaDeGestão.Controllers
{
    public class GrupoAdicionalController : Controller
    {
        private readonly DataBaseContext _context;

        public GrupoAdicionalController(DataBaseContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult CriarGrupoAdicional([FromBody] GrupoAdicionalViewModel model)
        {
            if (ModelState.IsValid)
            {
                var grupoAdicional = new GrupoAdicional
                {
                    Nome = model.Nome,
                    Adicionais = model.Adicionais.Select(a => new Adicional
                    {
                        Nome = a.Nome,
                        PrecoAdicional = a.Preco,
                    }).ToList()
                };

                _context.GrupoAdicionais.Add(grupoAdicional);
                _context.SaveChanges();

                return Json(new { success = true });
            }

            return Json(new { success = false, message = "Dados inválidos." });
        }
    }
}

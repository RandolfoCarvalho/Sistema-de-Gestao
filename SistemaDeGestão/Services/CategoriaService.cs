using SistemaDeGestão.Data;
using SistemaDeGestão.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaDeGestão.Models.ViewModel;

namespace SistemaDeGestão.Services
{
    public class CategoriaService
    {
        private readonly DataBaseContext _context;
        public CategoriaService(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<List<Categoria>> ListarCategorias()
        {
            return await _context.Categorias.Include(p => p.Produtos).ToListAsync();
        }
        public ProdutoViewModel GetCategorias()
        {
            var model = new ProdutoViewModel
            {
                Categorias = _context.Categorias.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),  // O valor será o nome da categoria
                    Text = c.Nome    // O texto exibido será o nome da categoria
                }).ToList()
            };
            return model;
        }
        public async void AdicionarCategoria(Categoria categoria)
        {
            try
            {
                _context.Add(categoria);
                _context.SaveChanges();
            } catch (Exception e)
            {
                throw new Exception("Erro ao salvar nova categoria" + e.Message);
            }
        }
        public async void AtualizarCategoria(Categoria categoria)
        {
            var current = _context.Categorias.FirstOrDefault(p => p.Id == categoria.Id);
            try
            {
                _context.Entry(current).CurrentValues.SetValues(categoria);
                _context.SaveChanges();
            } catch (Exception e)
            {
                throw new Exception("Erro ao atualizar categoria" + e.Message);
            }
        }
        public async void DeletarCategoria(int id)
        {
            var current = _context.Categorias.FirstOrDefault(p => p.Id == id);
            try
            {
                _context.Categorias.Remove(current);
                _context.SaveChanges();
            } catch(Exception e)
            {
                throw new Exception("Erro ao deletar categoria" + e.Message);
            }
        }
        public string ObterNomeCategoriaPorId(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(p => p.Id == id); // Implemente esse método no seu serviço
            return categoria?.Nome ?? "Categoria Desconhecida";
        }
    }
}

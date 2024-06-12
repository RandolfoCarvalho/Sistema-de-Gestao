using Microsoft.EntityFrameworkCore;
using SistemaDeGestão.Data;
using SistemaDeGestão.Models;

namespace SistemaDeGestão.Services
{
    public class ProdutoService
    {
        private readonly DataBaseContext _context;
        public ProdutoService(DataBaseContext context)
        {
            {
                _context = context;
            }
        }
        public async Task<List<Produto>> ListarProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }
        public void AdicionarProduto(Produto produto)
        {
            try
            {
                _context.Produtos.Add(produto);
                _context.SaveChanges();

            } catch (Exception e)
            {
                throw new Exception("Não foi possivel adicionar um novo produto " + e.Message);
            }
        }
        public void AtualizarProduto(Produto produto)
        {
            var current = _context.Produtos.FirstOrDefault(p => p.Id == produto.Id);
            try
            {
                _context.Entry(current).CurrentValues.SetValues(produto);
                _context.SaveChanges();
            } catch (Exception e)
            {
                throw new Exception("Não foi possivel atualizar o produto " + e.Message);
            }
        }
        public void DeletarProduto(int id)
        {
            var result = _context.Produtos.FirstOrDefault(p => p.Id == id);
            try
            {
                _context.Produtos.Remove(result);
                _context.SaveChanges();
            } catch (Exception e)
            {
                throw new Exception("Não foi possivel deletar o produto " + e.Message);
            }
        }
    }
}

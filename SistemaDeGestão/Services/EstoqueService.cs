using Microsoft.EntityFrameworkCore;
using SistemaDeGestão.Data;
using SistemaDeGestão.Models;

namespace SistemaDeGestão.Services
{
    public class EstoqueService
    {
        private readonly DataBaseContext _context;
        public EstoqueService(DataBaseContext context)
        {
            _context = context;
        }


        public void AtualizarQuantidade(Produto produto)
        {
            var estoque = _context.Estoques.FirstOrDefault(p => p.Id == produto.EstoqueId);
            if (estoque == null) return;
            try
            {
                estoque.Quantidade += produto.QuantidadeEstoque;
                _context.Update(estoque);
                _context.SaveChanges();

            } catch (Exception e)
            {
                throw new Exception("Erro em atualizar quantidade de estoque" + e.Message);
            }
        }
    }
}

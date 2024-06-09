using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeGestão.Data;
using SistemaDeGestão.Models;

namespace SistemaDeGestão.Services
{
    public class MovimentacaoService
    {
        private readonly DataBaseContext _context;
        public MovimentacaoService(DataBaseContext context)
        {
            _context = context;
        }
        public async Task<List<Movimentacao>> ListarMovimentacoes()
        {
            return await _context.Movimentacoes.ToListAsync();
        }
        public void AdicionaMovimentacao([FromBody] Movimentacao mov)
        {
            if (mov == null) throw new ArgumentNullException(nameof(mov), "Movimentacao is null");
            try
            {
                _context.Movimentacoes.Add(mov);
                var produto = _context.Produtos.FirstOrDefault(p => p.Id == mov.ProdutoId);
                if (produto == null) throw new ArgumentException("Produto não encontrado na base de dados", nameof(mov.ProdutoId));
                if (mov.TipoMovimentacao == "Entrada")
                {
                    produto.QuantidadeEstoque += mov.Quantidade;
                }
                if (mov.TipoMovimentacao == "Saida" && produto.QuantidadeEstoque > 0)
                {
                    produto.QuantidadeEstoque -= mov.Quantidade;
                }
                else
                {
                    throw new InvalidOperationException("Produto sem estoque disponível para retirada");
                }
                _context.Update(produto);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao tentar inicializar quantidade de produto");
            }
        }
    }
}

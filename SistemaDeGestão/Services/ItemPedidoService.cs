using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeGestão.Data;
using SistemaDeGestão.Models;

namespace SistemaDeGestão.Services
{
    public class ItemPedidoService
    {
        private readonly DataBaseContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ItemPedidoService(DataBaseContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<ItemPedido>> GetItensPedido()
        {
            return await _context.ItensPedido.ToListAsync();
        }
        public async Task<ItemPedido> GetItemPedido(int id)
        {
            try
            {
                var itemPedido = await _context.ItensPedido.FindAsync(id);
                return itemPedido;
            } catch (Exception e)
            {
                throw new Exception("Erro ao buscar pedido" + e.Message);
            }
        }
        public async Task<ItemPedido> PostItemPedido(ItemPedido itemPedido)
        {
            // Verifica se o produto existe
            var produto = await _context.Produtos.FindAsync(itemPedido.ProdutoId);

            // Verifica se já existe um Pedido em andamento na sessão
            HttpContext _httpContext = _httpContextAccessor.HttpContext;
            int? pedidoId = _httpContext.Session.GetInt32("PedidoId");
            Pedido pedido;

            if (pedidoId == null)
            {
                // Se não houver um Pedido em andamento, cria um novo Pedido
                pedido = new Pedido { Status = "Em andamento", Data = DateTime.Now };
                _context.Pedidos.Add(pedido);
                await _context.SaveChangesAsync();

                // Salva o Id do Pedido na sessão para futuras operações
                _httpContext.Session.SetInt32("PedidoId", pedido.Id);
            }
            else
            {
                // Se já existir um Pedido em andamento, carrega-o do banco de dados
                pedido = await _context.Pedidos
                    .Include(p => p.Itens)
                    .FirstOrDefaultAsync(p => p.Id == pedidoId.Value);
                if (pedido == null)
                {
                    throw new Exception ("Pedido não encontrado.");
                }
            }

            // Configura o preço unitário do item com base no preço do produto
            itemPedido.PrecoUnitario = produto.Preco;

            // Adiciona o item ao pedido atual
            itemPedido.PedidoId = pedido.Id;
            pedido.Itens.Add(itemPedido);

            // Adiciona o item ao contexto e salva no banco de dados
            _context.ItensPedido.Add(itemPedido);
            await _context.SaveChangesAsync();
            return (itemPedido);
        }
        public async Task PutItemPedido(int id, ItemPedido itemPedido)
        {
            _context.Entry(itemPedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (ItemPedidoExists(id))
                {
                    throw new DbUpdateConcurrencyException("DbUpdateConcurrencyException");
                }

            }
        }
        public async Task DeleteItemPedido(int id)
        {
            try
            {
                var itemPedido = await _context.ItensPedido.FindAsync(id);
                var pedido = await _context.Pedidos
                    .Include(p => p.Itens)
                    .FirstOrDefaultAsync(p => p.Id == itemPedido.PedidoId);

                _context.ItensPedido.Remove(itemPedido);
                await _context.SaveChangesAsync();

                // Verifica se o pedido não tem mais nenhum item associado
                if (pedido.Itens.Count == 0)
                {
                    _context.Pedidos.Remove(pedido);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
               throw new Exception($"Erro interno ao deletar o item: {e.Message}");
            }
        }
        private bool ItemPedidoExists(int id)
        {
            return _context.ItensPedido.Any(e => e.Id == id);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using SistemaDeGestão.Models;

namespace SistemaDeGestão.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() { }
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base (options)
        {

        }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Estoque> Estoques { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }

    }
}

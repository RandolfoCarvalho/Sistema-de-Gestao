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
    }
}

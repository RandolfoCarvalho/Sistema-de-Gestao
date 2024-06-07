namespace SistemaDeGestão.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        // Relacionamento: uma categoria pode ter muitos produtos
        public ICollection<Produto> Produtos { get; set; }
    }
}

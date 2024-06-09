    namespace SistemaDeGestão.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public int QuantidadeEstoque { get; set; }
        // Chave estrangeira para Categoria
        public int CategoriaId { get; set; }
    }
}

    namespace SistemaDeGestão.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public int CategoriaId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public string ProductImage { get; set; }
        public int QuantidadeEstoque { get; set; }
        public int? AdicionalId { get; set; }
    }
}

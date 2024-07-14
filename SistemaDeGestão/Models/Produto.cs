    namespace SistemaDeGestão.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public string ProductImage { get; set; }

        public ICollection<ProductCategory> Categories { get; set; }
        public int QuantidadeEstoque { get; set; }
    }
}

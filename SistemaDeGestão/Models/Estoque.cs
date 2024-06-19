namespace SistemaDeGestão.Models
{
    public class Estoque
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public string Localizacao { get; set; }
        public ICollection<Produto> Produtos { get; set; }  
    }
}

namespace SistemaDeGestão.Models
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int CategoriaId { get; set; }
        public Produto Produto { get; set; }
        public Categoria Categoria { get; set; }
    }
}

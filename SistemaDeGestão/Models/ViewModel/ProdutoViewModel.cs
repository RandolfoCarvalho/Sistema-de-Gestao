using System.ComponentModel.DataAnnotations;

namespace SistemaDeGestão.Models.ViewModel
{
    public class ProdutoViewModel
    {
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        [Required(ErrorMessage = "O preço do produto é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço do produto deve ser maior que zero.")]
        public double Preco { get; set; }

        public string ProductImage { get; set; }

        [Required(ErrorMessage = "A quantidade em estoque é obrigatória.")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade em estoque deve ser maior que zero.")]
        public int QuantidadeEstoque { get; set; }
    }
}

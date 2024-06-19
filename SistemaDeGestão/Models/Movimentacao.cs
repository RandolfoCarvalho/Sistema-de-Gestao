using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeGestão.Models
{
    [Table("Movimentacoes")]
    public class Movimentacao
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public string Localizacao { get; set; }
        public DateTime DataMovimentacao { get; set; }
        public string TipoMovimentacao { get; set; } // Entrada, Saída, Ajuste, etc.

    }
}

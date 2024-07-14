namespace SistemaDeGestão.Models
{
    public class Adicional
    {
        public int Id{ get; set; }
        public string Nome { get; set; }
        public decimal PrecoAdicional { get; set; }
        public int ItemPedidoId { get;set; }
    }
}

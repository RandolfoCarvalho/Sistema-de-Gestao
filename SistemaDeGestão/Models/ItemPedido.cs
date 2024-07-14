namespace SistemaDeGestão.Models
{
    public class ItemPedido
    {
        public int Id  {get; set; }
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public double PrecoUnitario { get; set; }
        public double Subtotal
        {
            get { return Quantidade * PrecoUnitario; }
        }
        public List<Adicional> Adicionais { get; set; }
    }
}

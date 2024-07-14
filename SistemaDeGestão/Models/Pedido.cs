namespace SistemaDeGestão.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Status { get; set; }
        public double Total
        {
            get
            {
                double total = 0;
                foreach (var item in Itens)
                {
                    total += item.Subtotal;
                }
                return total;
            }
        }                                              
        public List<ItemPedido> Itens { get; set; }

        public Pedido()
        {
            Itens = new List<ItemPedido>();
        }
    }
}

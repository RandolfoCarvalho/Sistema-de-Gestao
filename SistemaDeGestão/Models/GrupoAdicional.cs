namespace SistemaDeGestão.Models
{
    public class GrupoAdicional
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        // Navigation Property
        public ICollection<Adicional> Adicionais { get; set; }
    }
}

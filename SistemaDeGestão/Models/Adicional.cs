namespace SistemaDeGestão.Models
{
    public class Adicional
    {
        public int Id{ get; set; }
        public string? Nome { get; set; }
        public double PrecoAdicional { get; set; }
        public int GrupoAdicionalId { get; set; }
        public GrupoAdicional? grupoAdicional { get; set; }
    }
}

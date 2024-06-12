using System.Runtime.Intrinsics.X86;

namespace SistemaDeGestão.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Tipo { get; set; }
        public DateTime DataDeCriação { get; set; }
    }
}

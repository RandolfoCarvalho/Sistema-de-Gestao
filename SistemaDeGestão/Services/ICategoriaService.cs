using SistemaDeGestão.Models;

namespace SistemaDeGestão.Services
{
    public interface ICategoriaService
    {
        Task<IEnumerable<Categoria>> GetAllCategoriasAsync();
        Task<Categoria> GetCategoriaByIdAsync(int id);
        Task AddCategoriaAsync(Categoria categoria);
    }
}

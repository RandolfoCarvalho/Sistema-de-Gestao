using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SistemaDeGestão.Data;
using SistemaDeGestão.Models;
using SistemaDeGestão.Repository;

namespace SistemaDeGestão.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IRepository<Categoria> _repository;

        public CategoriaService(IRepository<Categoria> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Categoria>> GetAllCategoriasAsync()
        {
            var result = await _repository.GetAllAsync();
            return result;
        }
        public Task<Categoria> GetCategoriaByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task AddCategoriaAsync(Categoria categoria)
        {
            throw new NotImplementedException();
        }
    }
}

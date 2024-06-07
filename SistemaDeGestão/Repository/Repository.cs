
using Microsoft.EntityFrameworkCore;
using SistemaDeGestão.Data;

namespace SistemaDeGestão.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataBaseContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(DataBaseContext context, DbSet<T> dbSet)
        {
            _context = context;
            _dbSet = dbSet;
        }
        public Task AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = await _dbSet.ToListAsync();
            return result;
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}

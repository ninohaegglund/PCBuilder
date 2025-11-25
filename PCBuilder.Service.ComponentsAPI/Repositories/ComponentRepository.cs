using Microsoft.EntityFrameworkCore;
using PCBuilder.Service.ComponentsAPI.IRepositories;
using PCBuilder.Services.ComponentsAPI.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PCBuilder.Service.ComponentsAPI.Repositories
{
    public class ComponentRepository : IComponentRepository
    {
        private readonly DataContext _context;

        public ComponentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<T?> GetByIdAsync<T>(int id) where T : class
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity is not null)
            {
                _context.Entry(entity).State = EntityState.Detached;
            }
            return entity;
        }

        public Task<List<T>> GetAllAsync<T>() where T : class =>
            _context.Set<T>().AsNoTracking().ToListAsync();
    }
}
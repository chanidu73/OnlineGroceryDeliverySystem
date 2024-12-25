using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliveryTrackingService.Data;
using Microsoft.EntityFrameworkCore;

namespace DeliveryTrackingService.Repositories
{
    public class RepositoryBase<T>:IRepositoryBase<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;
        public RepositoryBase(ApplicationDbContext context)
        {
            _context  = context;
            _dbSet = _context.Set<T>();

        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }


        public async Task DeleteAsync(int entity)
        {

            var del =await _context.Deliveries.FindAsync(entity);
            if(del != null)
            {
                _context.Deliveries.Remove(del);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public  void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
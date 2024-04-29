using AdManage.Application.Interfaces;
using AdManage.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdManage.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AdManageDbContext _adManageDbContext;
        public Repository(AdManageDbContext carBookContext)
        {
            _adManageDbContext = carBookContext;
        }
        public async Task CreateAsync(T entity)
        {
            _adManageDbContext.Set<T>().Add(entity);
            await _adManageDbContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _adManageDbContext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            return await _adManageDbContext.Set<T>().SingleOrDefaultAsync(filter);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _adManageDbContext.Set<T>().FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            _adManageDbContext.Set<T>().Remove(entity);
            await _adManageDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _adManageDbContext.Set<T>().Update(entity);
            await _adManageDbContext.SaveChangesAsync();
        }
    }
}

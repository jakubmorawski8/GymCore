using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GymCore.Application.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GymCore.Persistence.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly GymCoreDbContext _dbContext;

        public BaseRepository(GymCoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetPagedResponseAsync(IQueryable<T> query, int page, int pageSize)
        {
            var skip = (page - 1) * pageSize;
            var result = query.Skip(skip).Take(pageSize).ToListAsync();

            return await result;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<T> GetAll<TKey>(Expression<Func<T, TKey>> sortCondition, bool sortDesc = false, Expression<Func<T, bool>> whereCondition = null)
        {
            IQueryable<T> result;

            if (sortDesc)
            {
                result = _dbContext.Set<T>().OrderByDescending(sortCondition);
            }                
            else
            {
                result = _dbContext.Set<T>().OrderBy(sortCondition);
            }

            if(whereCondition != null)
            {
                result = result.Where(whereCondition);
            }

            return result;
        }
    }
}

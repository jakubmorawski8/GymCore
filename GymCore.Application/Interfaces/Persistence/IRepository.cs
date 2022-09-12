using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GymCore.Application.Interfaces.Persistence
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IReadOnlyList<T>> GetPagedResponseAsync(IQueryable<T> query, int page, int pageSize);
        IQueryable<T> GetAll<TKey>(Expression<Func<T, TKey>> sortCondition, bool sortDesc = false, Expression<Func<T, bool>> whereCondition = null);
    }
}

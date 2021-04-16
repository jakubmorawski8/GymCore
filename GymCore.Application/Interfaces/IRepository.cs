using System.Collections.Generic;
using System.Threading.Tasks;
using GymCore.Domain.Entities;

namespace GymCore.Application.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(long id);
        Task<IReadOnlyList<T>> ListAsync();
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}

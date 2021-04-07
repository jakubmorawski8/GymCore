using System.Collections.Generic;
using System.Threading.Tasks;
using GymCore.Core.Entities;

namespace GymCore.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync<T>(int id);
        Task<List<T>> ListAsync<T>();
        Task<List<T>> ListAsync<T>(ISpecification<T> spec);
        Task<T> AddAsync<T>(T entity);
        Task UpdateAsync<T>(T entity);
        Task DeleteAsync<T>(T entity);
    }
}

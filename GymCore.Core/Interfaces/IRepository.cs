using GymCore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GymCore.Core.Interfaces
{
    public interface IRepository<T> where T: BaseEntity
    {
        Task<T> GetByIdAsync<T>(int id);
        Task<List<T>> ListAsync<T>();
        Task<List<T>> ListAsync<T>(ISpecification<T> spec);
        Task<T> AddAsync<T>(T entity);
        Task UpdateAsync<T>(T entity);
        Task DeleteAsync<T>(T entity);
    }
}

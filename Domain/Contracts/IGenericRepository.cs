using Domain.Entities;
using Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetEntityWithSpecAsync(ISpecification<T> Spec);
        Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecification<T> Spec);

        Task Add(T Entity);
        Task Update(T Entity);
        Task Delete(T Entity);



    }
}

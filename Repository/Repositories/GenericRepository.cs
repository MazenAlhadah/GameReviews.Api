using Domain.Contracts;
using Domain.Entities;
using Domain.Specifications;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _db;
        public GenericRepository(AppDbContext db)
        {
            _db= db;
        }

        public Task Add(T Entity)
        {
            _db.Add(Entity);
            return _db.SaveChangesAsync();
        }

        public Task Delete(T Entity)
        {
            _db.Remove(Entity);
            return _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecification<T> Spec)
        {
            var Query =_db.Set<T>().AsQueryable();
            if(Spec.Criteria !=null) Query = Query.Where(Spec.Criteria);
            foreach (var Include in Spec.Includes) {
                Query = Query.Include(Include);
            }
            if (Spec.OrderBy != null)
            {
                Query = Query.OrderBy(Spec.OrderBy);

            }
            else if(Spec.OrderByDescending != null) {
                Query = Query.OrderByDescending(Spec.OrderByDescending);

            }
            return await Query.ToListAsync();

        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public Task<T?> GetEntityWithSpecAsync(ISpecification<T> Spec)
        {
            var Query = _db.Set<T>().AsQueryable();
            if (Spec.Criteria != null) Query = Query.Where(Spec.Criteria);
            foreach (var Include in Spec.Includes)
            {
                Query = Query.Include(Include);
            }
            if (Spec.OrderBy != null)
            {
                Query = Query.OrderBy(Spec.OrderBy);

            }
            else if (Spec.OrderByDescending != null)
            {
                Query = Query.OrderByDescending(Spec.OrderByDescending);

            }
            return Query.FirstOrDefaultAsync();
        }

        public Task Update(T Entity)
        {
            _db.Update(Entity);
            return _db.SaveChangesAsync();
        }
    }
}

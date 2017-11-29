using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using TaskManager.Models;
using System.Threading.Tasks;

namespace TaskManager.Providers
{
    public interface IRepository<T> where T : BaseModel
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        Task AddAsync(T item);
        Task AddRangeAsync(IEnumerable<T> items);

        Task RemoveAsync(T item);
        Task RemoveRangeAsync(IEnumerable<T> items);

        Task UpdateAsync(T item);
        Task UpdateRangeAsync(IEnumerable<T> items);
    }
}
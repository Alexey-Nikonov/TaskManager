using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SQLite;
using TaskManager.Models;
using Xamarin.Forms.Internals;

namespace TaskManager.Providers
{
    public class Repository<T> : IRepository<T> where T : BaseModel, new()
    {
        protected readonly SQLiteAsyncConnection context;
        public Repository(SQLiteAsyncConnection context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync() =>
            await context.Table<T>().ToListAsync();

        public async Task<T> GetAsync(int id) =>
          await context.GetAsync<T>(id);

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate) =>
          await context.Table<T>().Where(predicate).ToListAsync();

        public async Task AddAsync(T item) =>
          await context.InsertAsync(item);

        public async Task AddRangeAsync(IEnumerable<T> items) =>
          await context.InsertAllAsync(items);

        public async Task RemoveAsync(T item) =>
          await Task.Run(() => context.DeleteAsync(item));

        public async Task RemoveRangeAsync(IEnumerable<T> items) =>
          await Task.Run(() => items.ToList().ForEach(item => context.DeleteAsync(item)));

        public async Task UpdateAsync(T item) =>
          await context.UpdateAsync(item);

        public async Task UpdateRangeAsync(IEnumerable<T> items) =>
          await context.UpdateAllAsync(items);
    }
}
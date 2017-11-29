using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

using TaskManager.Models;

namespace TaskManager.Providers
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SQLiteAsyncConnection context;
        private Dictionary<string, object> repositories;
        private bool disposed;

        public UnitOfWork(SQLiteAsyncConnection context)
        {
            this.context = context;

            this.repositories = new Dictionary<string, object>
            {
                { typeof(TodoItem).Name, new TodoItemRepository(this.context) },
                { typeof(ClockItem).Name, new ClockItemRepository(this.context) }
            };
        }

        public IRepository<T> GetRepository<T>() where T: BaseModel
        {
            string typeName = typeof(T).Name;
            return repositories[typeName] as IRepository<T>;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;

            if (disposing)
            {
                SQLiteAsyncConnection.ResetPool();
            }

            disposed = true;
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}

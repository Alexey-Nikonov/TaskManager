using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

using TaskManager.Models;

namespace TaskManager.Providers
{
    public class TodoItemRepository : Repository<TodoItem>, ITodoItemRepository
    {
        public TodoItemRepository(SQLiteAsyncConnection context) : base(context) { }

        public SQLiteAsyncConnection Context
        {
            get { return this.context as SQLiteAsyncConnection; }
        }
    }
}

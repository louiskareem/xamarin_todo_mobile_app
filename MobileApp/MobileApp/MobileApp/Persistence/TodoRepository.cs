using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Xamarin.Forms;

namespace MobileTodoApp.Persistence
{
    public class TodoRepository
    {
        private readonly SQLiteAsyncConnection connection;

        public TodoRepository()
        {
            connection = new SQLiteAsyncConnection(DependencyService.Get<IFileHelper>().GetLocalFilePath("TodoSQLite.db3"));
            //connection = new SQLiteAsyncConnection("TODO: file path");
            connection.CreateTableAsync<TodoItem>().Wait();
        }

        private List<TodoItem> TodoList = new List<TodoItem>
        {
            new TodoItem { ID = 0, Title = "Create first item", IsCompleted = true },
            new TodoItem { ID = 1, Title = "Run a marathon"},
            new TodoItem { ID = 2, Title = "Buy a new IPhone"},
        };

        public async Task<List<TodoItem>> GetList()
        {
            //return Task.FromResult(TodoList);
            //TODO: remove once Add is implemented

            if ((await connection.Table<TodoItem>().CountAsync() == 0))
            {
                await connection.InsertAllAsync(TodoList);
            }

            return await connection.Table<TodoItem>().ToListAsync();
        }

        public Task DeleteItem (TodoItem todoItem)
        {
            TodoList.Remove(todoItem);
            // We're using Task.Delay to simulate async behavior for now. It will be replaced by real async database calls
            //return Task.Delay(100);
            return connection.DeleteAsync(todoItem);
        }

        public Task ChangeItemIsCompleted (TodoItem todoItem)
        {
            todoItem.IsCompleted = !todoItem.IsCompleted;

            //return Task.Delay(100);

            return connection.UpdateAsync(todoItem);
        }

        public Task AddItem (TodoItem todoItem)
        {
            throw new NotImplementedException();
        }
    }
}

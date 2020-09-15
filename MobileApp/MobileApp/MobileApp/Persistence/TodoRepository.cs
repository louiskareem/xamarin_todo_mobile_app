using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileTodoApp.Persistence
{
    public class TodoRepository
    {
        private List<TodoItem> TodoList = new List<TodoItem>
        {
            new TodoItem { ID = 0, Title = "Create first item", IsCompleted = true },
            new TodoItem { ID = 1, Title = "Run a marathon"},
            new TodoItem { ID = 2, Title = "Buy a new IPhone"},
        };

        public Task<List<TodoItem>> GetList()
        {
            return Task.FromResult(TodoList);
        }

        public Task DeleteItem (TodoItem todoItem)
        {
            TodoList.Remove(todoItem);
            // We're using Task.Delay to simulate async behavior for now. It will be replaced by real async database calls
            return Task.Delay(100);
        }

        public Task ChangeItemIsCompleted (TodoItem todoItem)
        {
            todoItem.IsCompleted = !todoItem.IsCompleted;

            return Task.Delay(100);
        }

        public Task AddItem (TodoItem todoItem)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using MobileApp;
using System.Threading.Tasks;

namespace MobileTodoApp
{
    public class TodoListViewModel : BaseFodyObservable
    {
        public String Title => "My Todo List";

        public TodoListViewModel()
        {
            GetGroupedTodoList().ContinueWith(t =>
            {
                GroupedTodoList = t.Result;
            });
            Delete = new Command<TodoItem>(HandleDelete);
            ChangeIsCompleted = new Command<TodoItem>(HandleChangeIsCompleted);
        }

        public ILookup<String, TodoItem> GroupedTodoList { get; set; }
        public Command<TodoItem> Delete { get; set; }
        public Command<TodoItem> ChangeIsCompleted { get; set; }

        private List<TodoItem> TodoList = new List<TodoItem>
        {
            new TodoItem { ID = 0, Title = "Create first item", IsCompleted = true},
            new TodoItem { ID = 1, Title = "Run a marathon"},
            new TodoItem { ID = 2, Title = "Buy a new IPhone"},
        };

        private async Task<ILookup<String, TodoItem>> GetGroupedTodoList()
        {
            return (await App.TodoRepository.GetList())
                                .OrderBy(t => t.IsCompleted)
                                .ToLookup(t => t.IsCompleted ? "Completed" : "Active");
        }

        //private ILookup<String, TodoItem> GetGroupedTodoList()
        //{
        //    return TodoList.OrderBy(todo => todo.IsCompleted).ToLookup(todo => todo.IsCompleted ? "Completed" : "Active");
        //}

        public async void HandleDelete(TodoItem itemToDelete)
        {
            await App.TodoRepository.DeleteItem(itemToDelete);
            // Update displayed list
            GroupedTodoList = await GetGroupedTodoList();
        }

        public async void HandleChangeIsCompleted(TodoItem itemToUpdate)
        {
            await App.TodoRepository.ChangeItemIsCompleted(itemToUpdate);
            // Update displayed list
            GroupedTodoList = await GetGroupedTodoList();
        }
    }
}

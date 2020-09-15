using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace MobileTodoApp
{
    public class TodoListViewModel : BaseFodyObservable
    {
        public String Title => "My Todo List";

        public TodoListViewModel()
        {
            GroupedTodoList = GetGroupedTodoList();
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

        private ILookup<String, TodoItem> GetGroupedTodoList()
        {
            return TodoList.OrderBy(todo => todo.IsCompleted).ToLookup(todo => todo.IsCompleted ? "Completed" : "Active");
        }

        public void HandleDelete(TodoItem todoItem)
        {
            TodoList.Remove(todoItem);

            GroupedTodoList = GetGroupedTodoList();
        }

        public void HandleChangeIsCompleted (TodoItem todoItem)
        {
            // Change item's IsCompleted flag
            todoItem.IsCompleted = !todoItem.IsCompleted;

            GroupedTodoList = GetGroupedTodoList();
        }
    }
}

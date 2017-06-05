using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PomodoroTodo.Models;

namespace PomodoroTodo.Services
{
    public class MockService : IService
    {
        List<TodoItem> items { get; set; } = new List<TodoItem>();

        public MockService()
        {
            if (items.Count == 0)
                items = ToDos();
        }

        public Task<TodoItem> AddToDo(string text, bool complete)
        {
            var item = new TodoItem
                       {
                           Text = text,
                           Complete = complete
                       };

            items.Add(item);
            return Task.FromResult(item);
        }

        public Task<TodoItem> UpdateItem(TodoItem item)
        {
            var todo = items.FirstOrDefault(x => x.Id == item.Id);
            items.Remove(todo);
            items.Add(item);
            return Task.FromResult(item);
        }

        public Task<bool> DeleteItem(TodoItem item)
        {
            items.Remove(item);
            return Task.FromResult(true);
        }

        public Task<IEnumerable<TodoItem>> GetToDos()
        {
            IEnumerable<TodoItem> todos = items.AsEnumerable();
            return Task.FromResult(todos);
        }

        public Task Initialize()
        {
            return null;
        }

        public Task SyncToDos()
        {
            return null;
        }

        List<TodoItem> ToDos()
        {
            var items = new List<TodoItem>();

            var todo1 = new TodoItem
                        {
                            Text = "Llamar a lan - KM lan pass",
                            Complete = false
                        };
            items.Add(todo1);

            var todo2 = new TodoItem
                        {
                            Text = "Traducir prensetacion",
                            Complete = true
                        };
            items.Add(todo2);

            var todo3 = new TodoItem
                        {
                            Text = "Definir caracteristicas del MVP de PomodoroTodo" ,
                            Complete = false
                        };
            items.Add(todo3);


            var todo4 = new TodoItem
                        {
                            Text = "Revisar estado de el pedido del Wacom Spark",
                            Complete = false
                        };
            items.Add(todo4);

            return items;
        }
    }
}

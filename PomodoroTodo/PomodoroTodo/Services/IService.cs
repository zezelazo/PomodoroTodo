using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PomodoroTodo.Models;

namespace PomodoroTodo.Services
{
    public interface IService
    {
        Task Initialize();

        Task<IEnumerable<TodoItem>> GetToDos();

        Task<TodoItem> AddToDo(string text, bool complete);

        Task<TodoItem> UpdateItem(TodoItem item);

        Task<bool> DeleteItem(TodoItem item);

        Task SyncToDos();
    }
}

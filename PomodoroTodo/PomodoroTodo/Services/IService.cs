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

        Task<IEnumerable<ToDoItem>> GetToDos();

        Task<ToDoItem> AddToDo(string text, bool complete);

        Task<ToDoItem> UpdateItem(ToDoItem item);

        Task<bool> DeleteItem(ToDoItem item);

        Task SyncToDos();
    }
}

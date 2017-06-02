using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PomodoroTodo.Helpers;

namespace PomodoroTodo.Models
{
    public class ToDoItem : EntityData
    {
        public string Text { get; set; }

        public bool Complete { get; set; }
    }
}

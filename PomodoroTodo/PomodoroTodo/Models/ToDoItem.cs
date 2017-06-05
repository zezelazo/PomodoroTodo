using System;
using System.Collections.Generic;
using PomodoroTodo.Helpers;

namespace PomodoroTodo.Models
{
  public class TodoItem : EntityData
  {
    public string Text { get; set; }
    public bool Complete { get; set; }
    public DateTime CompletedOn { get; set; }
    public Project Project { get; set; }
    public ICollection<Pomodoro> Pomodoros { get; set; }
  }
}
using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Azure.Mobile.Server;

namespace PomodoroTodo.Api.DataObjects
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
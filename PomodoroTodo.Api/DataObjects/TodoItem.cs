using System;
using Microsoft.Azure.Mobile.Server;

namespace PomodoroTodo.Api.DataObjects
{
  public class TodoItem : EntityData
  {
    public string Text { get; set; }

    public bool Complete { get; set; }

  }
}
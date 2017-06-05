using System;
using Microsoft.Azure.Mobile.Server;

namespace PomodoroTodo.Api.DataObjects {
  public class User : EntityData {
    public string UserName { get; set; }
    public DateTime LastLogin { get; set; }
    public int ShortRest { get; set; }
    public int LongRest { get; set; }
    public int PomodoroDuration { get; set; }
  }
}
using System;
using PomodoroTodo.Helpers;

namespace PomodoroTodo.Models {
  public class User : EntityData {
    public string UserName { get; set; }
    public DateTime LastLogin { get; set; }
    public int ShortRest { get; set; }
    public int LongRest { get; set; }
    public int PomodoroDuration { get; set; }
  }
}
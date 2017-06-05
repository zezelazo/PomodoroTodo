using System;
using PomodoroTodo.Helpers;

namespace PomodoroTodo.Models {
  public class Pomodoro : EntityData {
    public DateTime Start { get;set; }
    public DateTime Stop { get; set; }
    public int Duration { get; set; }
    public TodoItem TodoItem { get; set; }
    public double Earned { get; set; }
  }
}
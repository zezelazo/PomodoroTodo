using System;
using System.Collections.Generic;
using PomodoroTodo.Helpers;

namespace PomodoroTodo.Models {
  public class Project:EntityData {
    public string Name { get; set; }     
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Description { get; set; }
    public Customer Cutomer { get; set; }
    public int ShortRest { get; set; }
    public int LongRest { get; set; }
    public int PomodoroDuration { get; set; }
    public Double Rate { get; set; }
    public ERateType RateType { get; set; }
    public ICollection<TodoItem> TodoItems { get; set; }
  }
}